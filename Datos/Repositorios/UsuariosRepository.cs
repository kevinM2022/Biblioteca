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
    public class UsuarioRepository: MasterRepository,IUsuarioRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public UsuarioRepository()
        {
            selectAll = "SELECT * FROM Usuario";
            insert = "INSERT INTO Libros VALUES ()";
            update = "UPDATE Products SET";
            delete = "DELETE FROM Libros WHERE IdUsuario = @IdUsuario";
        }

        public int Add(UsuarioDTO entity)
        {
            parameters = new List<SqlParameter>();            
            parameters.Add(new SqlParameter("@Nombre", entity.Nombre));
            parameters.Add(new SqlParameter("@Apellido", entity.Apellido));
            parameters.Add(new SqlParameter("@Correo", entity.Correo));
            parameters.Add(new SqlParameter("@Telefono", entity.Telefono));
            parameters.Add(new SqlParameter("@Direccion", entity.Direccion));
            parameters.Add(new SqlParameter("@Rol", entity.Rol));

            return ExecuteNonQuery(insert);
        }

        public int Adit(UsuarioDTO entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Nombre", entity.Nombre));
            parameters.Add(new SqlParameter("@Apellido", entity.Apellido));
            parameters.Add(new SqlParameter("@Correo", entity.Correo));
            parameters.Add(new SqlParameter("@Telefono", entity.Telefono));
            parameters.Add(new SqlParameter("@Direccion", entity.Direccion));
            parameters.Add(new SqlParameter("@Rol", entity.Rol));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<UsuarioDTO> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listUsuario = new List<UsuarioDTO>();
            foreach (DataRow item in tableResult.Rows)
            {
                listUsuario.Add(new UsuarioDTO
                {
                    IdUsuario = Convert.ToInt32(item[0]),
                    Nombre = item[1].ToString(),
                    Apellido = item[2].ToString(),
                    Correo = item[3].ToString(),
                    Telefono = item[4].ToString(),
                    Direccion = item[5].ToString(),
                    Rol = item[6].ToString(),
                });
            }
            return listUsuario;
        }

        public int Remove(int id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdUsuario", id));

            return ExecuteNonQuery(delete);
        }

        public UsuarioDTO ValidacionUser(UsuarioDTO usuario)
        {
            throw new NotImplementedException();
        }
    }
}
