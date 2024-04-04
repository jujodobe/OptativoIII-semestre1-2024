using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptativoIII_introduccion.Modelos
{
    public class Alumno : Persona
    {
        public int semestre { get; set; }
        public string carrera { get; set; }

        public override void imprimirResponsabilidad()
        {
            Console.WriteLine($"Usted es un Alumno");
        }
    }
}
