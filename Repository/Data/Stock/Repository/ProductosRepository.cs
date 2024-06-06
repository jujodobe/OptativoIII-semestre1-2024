using Repository.Data.ConfiguracionesDB;
using Repository.Data.Stock.Modelos;
using System.Data;
using System.Linq;
using Dapper;

namespace Repository.Data.Stock.Repository
{
    public class ProductosRepository : IProductos
    {
        IDbConnection connection;

        public ProductosRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        bool IProductos.add(ProductosModel modelo)
        {
            try
            {
                connection.Execute("INSERT INTO productos(descripcion, cantidad_minima, tipo_iva, estado) " +
                        " values(@descripcion, @cantidad_minima, @tipo_iva, @estado)", modelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        bool IProductos.delete(int id)
        {
            try
            {
                connection.Execute("delete from productos where id = @id", id);
                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        IEnumerable<ProductosModel> IProductos.getAll()
        {
            return connection.Query<ProductosModel>("SELECT * FROM Productos;");
        }

        ProductosModel IProductos.getById(int id)
        {
            try
            {
                return connection.QuerySingle<ProductosModel>("SELECT * FROM productos where id = @id", id);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        bool IProductos.update(ProductosModel modelo)
        {
            try
            {
                connection.Execute("UPDATE productos SET " +
                    " descripcion = @descripcion," +
                    " cantidad_minima = @cantidad_minima, " +
                    " tipo_iva = @tipo_iva, " +
                    " estado = @estado WHERE id = @id ", modelo);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
