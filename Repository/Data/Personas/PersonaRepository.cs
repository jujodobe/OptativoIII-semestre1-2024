using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Repository.Data.ConfiguracionesDB;

namespace Repository.Data.Personas
{
    public class PersonaRepository
    {
        NpgsqlConnection connection;
        public PersonaRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(PersonaModel personaModel)
        {
            try
            {
                var cmd = connection.CreateCommand();
                cmd.CommandText = "INSERT INTO Persona(nombre, apellido, cedula, fechaNacimiento, correo, estado) " +
                    $"Values(" +
                    $"'{personaModel.nombre}', " +
                    $"'{personaModel.apellido}'," +
                    $"'{personaModel.cedula}'," +
                    $"'{personaModel.fechaNacimiento}'," +
                    $"'{personaModel.correo}'," +
                    $"'{personaModel.estado}')";
                cmd.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<PersonaModel> list()
        {
            List<PersonaModel> personas = new List<PersonaModel>();

            var cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM persona";
            var list = cmd.ExecuteReader();


            while (list.Read())
            {
                personas.Add(new PersonaModel { 
                    nombre = list.GetString(1),
                    apellido = list.GetString(2),
                    cedula = list.GetString(3),
                    correo = list.GetString(5),
                    fechaNacimiento = list.GetDateTime(4),
                    estado = list.GetString(6)
                });
            }
            
            return personas;
        }
    }
}
