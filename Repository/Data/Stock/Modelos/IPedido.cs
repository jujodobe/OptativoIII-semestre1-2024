using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Stock.Modelos
{
    public interface IPedido
    {
        bool add(PedidosModel pedidos);
        bool update(PedidosModel pedidos);
        bool delete(int id);
        PedidosModel getById(int id);
        IEnumerable<PedidosModel> GetAll();


    }
}
