using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Repositories;
using Datos.Interfaz;
using Datos.Entidades;

namespace Datos.Repositorios
{
    public class SancionRepository: MasterRepository, ISancionRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public SancionRepository()
        {
            selectAll = "SELECT * FROM Multas";
            insert = "INSERT INTO Multas VALUES ()";
            update = "UPDATE Products SET";
            delete = "DELETE FROM Multas WHERE IdMulta = @IdSancion";
        }

        public int Add(SancionDTO entity)
        {
            parameters = new List<SqlParameter>();   
            parameters.Add(new SqlParameter("@IdSancion", entity.IdSancion));         
            parameters.Add(new SqlParameter("@Concepto", entity.Concepto));
            parameters.Add(new SqlParameter("@Monto", entity.Monto));

            return ExecuteNonQuery(insert);
        }

        public int Adit(SancionDTO entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdLibro", entity.IdSancion));
            parameters.Add(new SqlParameter("@Concepto", entity.Concepto));
            parameters.Add(new SqlParameter("@Monto", entity.Monto));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<SancionDTO> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listsancion = new List<SancionDTO>();
            foreach (DataRow item in tableResult.Rows)
            {
                listsancion.Add(new SancionDTO
                {
                    IdSancion = Convert.ToInt32(item[0]),
                    Concepto = item[1].ToString(),
                    Monto = item[2].ToString(),
                });
            }
            return listsancion;
        }

        public int Remove(int id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdSancion", id));

            return ExecuteNonQuery(delete);
        }

        public UsuarioDTO ValidacionUser(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
