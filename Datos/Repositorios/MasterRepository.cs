using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DataAccess.Repositories
{
    //Clase general para las consulta a la BD
    public abstract class MasterRepository:Repository
    {
        protected List<SqlParameter> parameters;

        protected int ExecuteNonQuery(string transctSql) 
        { 
            using(var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transctSql;
                    command.CommandType = CommandType.Text;
                    foreach(SqlParameter item in parameters)
                    {
                        command.Parameters.Add(item);
                    }
                    int result = command.ExecuteNonQuery();
                    parameters.Clear();
                    return result;
                }
            }
        } //Ejecutar comandos de no consultas

        protected DataTable ExecuteReader(string transctSql) 
        {
            using (var connection = GetConnection())
            {
                connection.Open();
                using (var command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = transctSql;
                    command.CommandType = CommandType.Text;
                    SqlDataReader reader = command.ExecuteReader();
                    using (var table = new DataTable())
                    {
                        table.Load(reader);
                        reader.Dispose();
                        return table;
                    }                    
                }
            }
        } //Ejecutar comandos de consultas

    }
}
