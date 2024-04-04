using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptativoIII_introduccion.Modelos
{
    public class Colaborador : Persona
    {
        public string cargo { get; set; }
        public string antiguedad  { get; set; }

        public override void imprimirResponsabilidad()
        {
            Console.WriteLine($"Usted es un Colaborador");
        }
    }
}
