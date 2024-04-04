using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OptativoIII_introduccion.Modelos
{
    public abstract class Persona
    {
        private string nombre;
        private string apellido;
        public string nroCedula { get; set; }
        public string? mail { get; set; }
        public DateTime fechaNacimiento { get; set; }

        public string getApellido()
        {
            return apellido;
        }
        public void setApellido(string _apellido)
        {
            apellido = _apellido;
        }
        public string getNombre()
        {
            try
            {
                if (string.IsNullOrEmpty(nombre))
                    throw new Exception("El nombre no puede dejar vacìo");
                else
                    return nombre;
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void setNombre(string _nombre)
        {
            this.nombre = _nombre;
        }

        public abstract void imprimirResponsabilidad();
    }
}
