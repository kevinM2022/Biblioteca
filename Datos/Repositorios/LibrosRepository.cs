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
    public class LibrosRepository: MasterRepository, ILibrosRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public LibrosRepository()
        {
            selectAll = "SELECT * FROM Libros";
            insert = "INSERT INTO Libros VALUES ()";
            update = "UPDATE Products SET";
            delete = "DELETE FROM Libros WHERE IdLibro = @IdLibro";
        }

        public int Add(Libro entity)
        {
            parameters = new List<SqlParameter>();            
            parameters.Add(new SqlParameter("@Nombre", entity.Nombre));
            parameters.Add(new SqlParameter("@Autor", entity.Autor));
            parameters.Add(new SqlParameter("@IdLibro", entity.Autor));
            parameters.Add(new SqlParameter("@AnioPublicacion", entity.Autor));
            parameters.Add(new SqlParameter("@Categoria", entity.Autor));
            parameters.Add(new SqlParameter("@CantEjemplares", entity.Autor));
            parameters.Add(new SqlParameter("@EstadoFisico", entity.Autor));
            parameters.Add(new SqlParameter("@Genero", entity.Autor));


            return ExecuteNonQuery(insert);
        }

        public int Adit(Libro entity)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Nombre", entity.Nombre));
            parameters.Add(new SqlParameter("@Autor", entity.Autor));
            parameters.Add(new SqlParameter("@IdLibro", entity.Autor));
            parameters.Add(new SqlParameter("@AnioPublicacion", entity.Autor));
            parameters.Add(new SqlParameter("@Categoria", entity.Autor));
            parameters.Add(new SqlParameter("@CantEjemplares", entity.Autor));
            parameters.Add(new SqlParameter("@EstadoFisico", entity.Autor));
            parameters.Add(new SqlParameter("@Genero", entity.Autor));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<Libro> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listLibro = new List<Libro>();
            foreach (DataRow item in tableResult.Rows)
            {
                listLibro.Add(new Libro
                {
                    IdLibro = Convert.ToInt32(item[0]),
                    Nombre = item[1].ToString(),
                    Autor = item[2].ToString(),
                    AnioPublicacion = item[3].ToString(), 
                    Categoria = item[4].ToString(),
                    CantEjemplares= item[5].ToString(),
                    EstadoFisico= item[6].ToString(),
                    Genero= item[7].ToString(),

                });
            }
            return listLibro;
        }

        public int Remove(int id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdLibro", id));

            return ExecuteNonQuery(delete);
        }
    }
}
