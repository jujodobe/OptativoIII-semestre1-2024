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
                connection.Execute("INSERT INTO pedido_compra(fecha_pedido, observacion) " +
                    " values(@fecha_pedido, @observacion)");

                foreach (var producto in pedidos.detallePedido)
                {
                    connection.Execute("INSERT INTO detalle_pedido(id_pedido, id_producto, cantidad)" +
                        $" values({pedidos.id}, @id_producto, @cantidad)", producto);
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
                connection.Execute("DELETE FROM pedido WHERE id = @id", id);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IEnumerable<PedidosModel> GetAll()
        {
            throw new NotImplementedException();
        }

        public PedidosModel getById(int id)
        {
            throw new NotImplementedException();
        }

        public bool update(PedidosModel pedidos)
        {
            throw new NotImplementedException();
        }
    }
}
