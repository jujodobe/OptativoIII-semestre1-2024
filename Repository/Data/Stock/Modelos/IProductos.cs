using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Stock.Modelos
{
    public interface IProductos
    {
        bool add(ProductosModel modelo);
        bool update(ProductosModel modelo);
        bool delete(int id);
        ProductosModel getById(int id);
        IEnumerable<ProductosModel> getAll();
    }
}
