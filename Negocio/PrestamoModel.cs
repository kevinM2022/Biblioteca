using DataAccess.Contracts;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using Datos.Repositorios;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class PrestamoModel
    {
        private int idPrestamo;
        private string cantidadLibros;
        private string estadoPrestamo;
        private DateOnly fechaPrestamo;
        private DateOnly devolucion;

        private PrestamosRepository prestamoRepository;
        private List<PrestamoModel> listaPrestamos;

        public EntityState State { private get; set; }

        public int IdPrestamo { get => idPrestamo; set => idPrestamo = value; }
        public string CantidadLibros { get => cantidadLibros; set => cantidadLibros = value; }
        public string EstadoPrestamo { get => estadoPrestamo; set => estadoPrestamo = value; }
        public DateOnly FechaPrestamo { get => fechaPrestamo; set => fechaPrestamo = value; }
        public DateOnly Devolucion { get => devolucion; set => devolucion = value; }

        public PrestamoModel()
        {
            prestamoRepository = new PrestamosRepository();
        }

        public string SaveChanges()
        {
            string message = null;

            try
            {
                var prestamoDataModel = new PrestamoDTO();

                prestamoDataModel.IdPrestamo = idPrestamo;
                prestamoDataModel.CantidadLibros = cantidadLibros;
                prestamoDataModel.EstadoPrestamo = estadoPrestamo;
                prestamoDataModel.FechaPrestamo = fechaPrestamo;
                prestamoDataModel.Devolucion = devolucion;

                switch (State)
                {
                    case EntityState.Added:
                        prestamoRepository.Add(prestamoDataModel);
                        message = "Guardado Correctamente";
                        break;
                    case EntityState.Modified:
                        prestamoRepository.Adit(prestamoDataModel);
                        message = "Editado Correctamente";
                        break;
                    case EntityState.Deleted:
                        prestamoRepository.Remove(idPrestamo);
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

        public List<PrestamoModel> GetAll()
        {
            var prestamosDataModel = prestamoRepository.GetAll();
            listaPrestamos = new List<PrestamoModel>();

            foreach (PrestamoDTO item in prestamosDataModel)
            {
                listaPrestamos.Add(new PrestamoModel
                {
                    IdPrestamo = item.IdPrestamo,
                    CantidadLibros = item.CantidadLibros,
                    EstadoPrestamo = item.EstadoPrestamo,
                    FechaPrestamo = item.FechaPrestamo,
                    Devolucion = item.Devolucion
                });
            }

            return listaPrestamos;
        }
    }
}
