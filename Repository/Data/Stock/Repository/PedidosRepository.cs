using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Repository.Data.ConfiguracionesDB;
using Repository.Data.Stock.Modelos;

namespace Repository.Data.Stock.Repository
{
    public class PedidosRepository : IPedido
    {
        IDbConnection connection;
        public PedidosRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(PedidosModel pedidos)
        {
            try
            {
                var queryPedido = @"INSERT INTO pedido_compra(fecha_pedido, observacion, estado)
                                                       values(@fecha_pedido, @observacion, @estado); 

                                    SELECT CAST(SCOPE_IDENTITY() as int); ";

                connection.Execute(queryPedido, pedidos);
                
                var idPedido = connection.QuerySingle<int>(queryPedido, new
                {
                    pedidos.fecha_pedido,
                    pedidos.Observacion
                });

                foreach (var producto in pedidos.detallePedido)
                {
                    connection.Execute("INSERT INTO detalle_pedido(id_pedido, id_producto, cantidad)" +
                        $" values({idPedido}, @id_producto, @cantidad)", producto);
                }
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool update(PedidosModel pedidos)
        {
            try
            {
                var queryPedido = @"UPDATE pedido_compra SET 
                                   fecha_pedido=@fecha_pedido, 
                                   observacion=@observacion,
                                   estado = @estado
                                   WHERE id = @id";

                var queryDetallePedido = @"UPDATE detalle_pedido SET
                                          id_producto=@id_producto,
                                          cantidad=@cantidad 
                                          WHERE id = @id;";

                connection.Execute(queryPedido, pedidos);

                foreach (var producto in pedidos.detallePedido)
                {
                    connection.Execute(queryDetallePedido, producto);
                }

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public bool delete(int id)
        {
            try
            {
                connection.Execute("DELETE FROM detalle_pedido WHERE id_pedido = @id", id);
                connection.Execute("DELETE FROM pedido_compra WHERE id = @id", id);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PedidosModel> GetAll()
        {
            try
            {
                var pedidoDictonary = new Dictionary<int, PedidosModel>();
                var query = @" SELECT
                               pc.id, pc.fecha_pedido, pc.observacion, pc.estado
                               pd.id, pd.id_pedido, pd.id_producto, pd.cantidad
                               FROM pedido_compra pc
                               LEFT JOIN detalle_pedido dp on pc.id = dp.id_pedido 
                              ";

               var pedido = connection.Query<PedidosModel, DetallePedidoModel, PedidosModel>(query, (pedido, detalle_pedido) =>
                { 
                    if(!pedidoDictonary.TryGetValue(pedido.id, out var pedidoActual)) {
                        pedidoActual = pedido;
                        pedidoActual.detallePedido = new List<DetallePedidoModel>();
                        pedidoDictonary.Add(pedidoActual.id, pedidoActual);

                        if(detalle_pedido != null)
                        {
                            pedidoActual.detallePedido.Add(detalle_pedido);
                        }

                        return pedidoActual;
                    }
                }                     
                );
                return pedido;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public PedidosModel getById(int id)
        {
            throw new NotImplementedException();
        }


    }
}
