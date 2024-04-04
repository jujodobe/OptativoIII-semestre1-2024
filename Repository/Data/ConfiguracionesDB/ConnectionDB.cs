using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Repository.Data.ConfiguracionesDB
{
    public class ConnectionDB
    {
        private string connectionString = "Host=localhost;Username=postgres;Password=a.123456;Database=optativoIII;Port=5432";

        public NpgsqlConnection OpenConnection()
        {
            try
            {
                var conn = new NpgsqlConnection(connectionString);
                conn.Open();
                return conn;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
