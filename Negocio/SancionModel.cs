using DataAccess.Contracts;
using Datos.Repositorios;
using Datos.Entidades;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class SancionModel
    {
        private int idSancion;
        private string concepto;
        private string monto;

        private SancionRepository sancionRepository;
        private List<SancionModel> listaSanciones;

        public EntityState State { private get; set; }

        public int IdSancion { get => idSancion; set => idSancion = value; }
        public string Concepto { get => concepto; set => concepto = value; }
        public string Monto { get => monto; set => monto = value; }

        public SancionModel()
        {
            sancionRepository = new SancionRepository();
        }

        public string SaveChanges()
        {
            string message = null;

            try
            {
                var sancionDataModel = new SancionDTO();

                sancionDataModel.IdSancion = idSancion;
                sancionDataModel.Concepto = concepto;
                sancionDataModel.Monto = monto;

                switch (State)
                {
                    case EntityState.Added:
                        sancionRepository.Add(sancionDataModel);
                        message = "Guardado Correctamente";
                        break;
                    case EntityState.Modified:
                        sancionRepository.Adit(sancionDataModel);
                        message = "Editado Correctamente";
                        break;
                    case EntityState.Deleted:
                        sancionRepository.Remove(idSancion);
                        message = "Eliminado Correctamente";
                        break;
                }
            }
            catch (Exception e)
            {
                System.Data.SqlClient.SqlException sqlEx = e as System.Data.SqlClient.SqlException;
                if (sqlEx != null && sqlEx.Number == 2267)
                    message = "Registro Duplicado";
                else
                    message = e.ToString();
            }

            return message;
        }

        public List<SancionModel> GetAll()
        {
            var sancionesDataModel = sancionRepository.GetAll();
            listaSanciones = new List<SancionModel>();

            foreach (SancionDTO item in sancionesDataModel)
            {
                listaSanciones.Add(new SancionModel
                {
                    IdSancion = item.IdSancion,
                    Concepto = item.Concepto,
                    Monto = item.Monto
                });
            }

            return listaSanciones;
        }
    }
}
