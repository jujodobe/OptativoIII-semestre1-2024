using Repository.Data.Personas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Logica
{
    public class PersonaService : IPersonaRepository
    {
        private PersonaRepository personaRepository;
        public PersonaService(string connectionString)
        {
            personaRepository = new PersonaRepository(connectionString);
        }

        public bool add(PersonaModel persona)
        {
            return validarDatos(persona) ? personaRepository.add(persona) : throw new Exception("Error en la validación de datos, corroborar");
        }

        public IEnumerable<PersonaModel> GetAll() {
            return personaRepository.GetAll();
        }

        public bool delete(int id)
        {
            return id > 0 ? personaRepository.delete(id) : false;
        }


        public bool update(PersonaModel personaModel)
        {
            return validarDatos(personaModel) ? personaRepository.update(personaModel) : throw new Exception("Error en la validación de datos, corroborar");
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
