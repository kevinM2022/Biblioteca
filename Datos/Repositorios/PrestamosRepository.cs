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
    public class PrestamosRepository: MasterRepository, IPrestamosRepository
    {
        private string selectAll;
        private string insert;
        private string update;
        private string delete;

        public PrestamosRepository()
        {
            selectAll = "SELECT * FROM Prestamos";
            insert = "INSERT INTO Prestamos VALUES ()";
            update = "UPDATE Products SET";
            delete = "DELETE FROM Prestamos WHERE IdPrestamo = @IdPrestamo";
        }

        public int Add(PrestamoDTO entity)
        {
            parameters = new List<SqlParameter>();   
            parameters.Add(new SqlParameter("@IdPrestamo", entity.IdPrestamo));         
            parameters.Add(new SqlParameter("@CantidadLibros", entity.CantidadLibros));
            parameters.Add(new SqlParameter("@EstadoPrestamo", entity.EstadoPrestamo));
            parameters.Add(new SqlParameter("@FechaPrestamo", entity.FechaPrestamo));
            parameters.Add(new SqlParameter("@Devolucion", entity.Devolucion));

            return ExecuteNonQuery(insert);
        }

        public int Adit(PrestamoDTO entity)
        {
            parameters = new List<SqlParameter>();   
            parameters.Add(new SqlParameter("@IdPrestamo", entity.IdPrestamo));         
            parameters.Add(new SqlParameter("@CantidadLibros", entity.CantidadLibros));
            parameters.Add(new SqlParameter("@EstadoPrestamo", entity.EstadoPrestamo));
            parameters.Add(new SqlParameter("@FechaPrestamo", entity.FechaPrestamo));
            parameters.Add(new SqlParameter("@Devolucion", entity.Devolucion));

            return ExecuteNonQuery(update);
        }

        public IEnumerable<PrestamoDTO> GetAll()
        {
            var tableResult = ExecuteReader(selectAll);
            var listPrestamo= new List<PrestamoDTO>();
            foreach (DataRow item in tableResult.Rows)
            {
                listPrestamo.Add(new PrestamoDTO
                {
                    IdPrestamo = Convert.ToInt32(item[0]),
                    CantidadLibros = item[1].ToString(),
                    EstadoPrestamo = item[2].ToString(),
                    FechaPrestamo = (DateOnly)item[3], 
                    Devolucion = (DateOnly)item[4],

                });
            }
            return listPrestamo;
        }

        public int Remove(int id)
        {
            parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@IdPrestamo", id));

            return ExecuteNonQuery(delete);
        }
    }
}
