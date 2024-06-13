using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Stock.Modelos
{
    public class PedidosModel
    {
        public int id { get; set; }
        public DateTime fecha_pedido{ get; set; }
        public string Observacion { get; set; }
        public string estado { get; set; }
        public List<DetallePedidoModel> detallePedido { get; set; }
    }
}
