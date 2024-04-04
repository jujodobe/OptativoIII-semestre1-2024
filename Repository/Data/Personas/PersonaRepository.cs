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
        public PersonaRepository()
        {
            connection = new ConnectionDB().OpenConnection();
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
    }
}
