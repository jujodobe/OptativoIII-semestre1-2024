using Repository.Data.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class PersonaService
    {
        private PersonaRepository personaRepository;
        public PersonaService(string connectionString)
        {
            personaRepository = new PersonaRepository(connectionString);
        }

        public bool insertar(PersonaModel persona)
        {
            if (validarDatos(persona))
                return personaRepository.add(persona);
            else
                throw new Exception("Error en la validación de datos, favor corroborar");
        }

        public List<PersonaModel> listado() {
            return personaRepository.list();
        }

        private bool validarDatos(PersonaModel persona)
        {
            if(persona == null)
                return false;
            if(string.IsNullOrEmpty(persona.nombre))
                return false;
            if (string.IsNullOrEmpty(persona.apellido) && persona.nombre.Length < 2)
                return false;
            if (string.IsNullOrEmpty(persona.cedula))
                return false;

            return true;
        }
    }
}
