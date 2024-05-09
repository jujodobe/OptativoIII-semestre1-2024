using Dapper;
using Repository.Data.ConfiguracionesDB;
using System.Data;

namespace Repository.Data.Personas
{
    public class PersonaRepository : IPersonaRepository
    {
        IDbConnection connection;

        public PersonaRepository(string connectionString)
        {
            connection = new ConnectionDB(connectionString).OpenConnection();
        }

        public bool add(PersonaModel personaModel)
        {
            try
            {
                connection.Execute("INSERT INTO Persona(nombre, apellido, cedula, fechaNacimiento, correo, estado) " +
                    $"Values(@nombre, @apellido, @cedula, @fechaNacimiento, @correo, @estado)", personaModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<PersonaModel> GetAll()
        {
            return connection.Query<PersonaModel>("SELECT * FROM persona");
        }

        public bool delete(int id)
        {
            connection.Execute($"DELETE FROM persona WHERE id = {id}");
            return true;
        }
 
        public bool update(PersonaModel personaModel)
        {
            try
            {
                connection.Execute("UPDATE Persona SET " +
                    " nombre=@nombre, " +
                    " apellido=@apellido, " +
                    " cedula=@cedula, " +
                    " fechaNacimiento=@fechaNacimiento, " +
                    " correo=@correo, " +
                    " estado=@estado " +
                    $" WHERE  id = @id", personaModel);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
