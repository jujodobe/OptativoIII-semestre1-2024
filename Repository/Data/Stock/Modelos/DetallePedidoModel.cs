using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Stock.Modelos
{
    public class DetallePedidoModel
    {
        public int id { get; set; }
        public int id_pedido { get; set; }
        public int id_producto { get; set; }
        public double cantidad { get; set; }
    }
}
