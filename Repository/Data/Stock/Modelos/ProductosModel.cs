using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Stock.Modelos
{
    public class ProductosModel
    {
        public int id { get; set; }
        public string descripcion { get; set; }
        public double cantidad_minima { get; set; }
        public int tipo_iva { get; set; }
        public string estado { get; set; }
    }
}
