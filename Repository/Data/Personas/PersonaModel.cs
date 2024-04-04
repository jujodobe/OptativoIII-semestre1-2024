using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Data.Personas
{
    public class PersonaModel
    {
        public int Id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string cedula { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public string correo { get; set; }
        public string estado { get; set; }
    }
}
