using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;

namespace DataAccess.Repositories
{
    public abstract class Repository
    {
        private readonly string connectionString;
        public Repository ()
        {
            connectionString = ConfigurationManager.ConnectionStrings["defaultConnection"].ToString();
        } //Contructor
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        } //Método protegido para que la conexión solo pueda ser usada por la misma clases y aquellas que deriven de ella
    }
}
