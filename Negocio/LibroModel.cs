using DataAccess.Contracts;
using Datos.Repositorios;
using DataAccess.Repositories;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Datos.Entidades;

namespace Domain.Models
{
    public class LibroModel
    {
        private int idLibro;
        private string nombre;
        private string autor;
        private string anioPublicacion;
        private string categoria;
        private string cantEjemplares;
        private string estadoFisico;
        private string genero;

        private LibrosRepository librosRepository;
        private List<LibroModel> listaLibros;

        public EntityState State { private get; set; }

        public int IdLibro { get => idLibro; set => idLibro = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Autor { get => autor; set => autor = value; }
        public string AnioPublicacion { get => anioPublicacion; set => anioPublicacion = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string CantEjemplares { get => cantEjemplares; set => cantEjemplares = value; }
        public string EstadoFisico { get => estadoFisico; set => estadoFisico = value; }
        public string Genero { get => genero; set => genero = value; }

        public LibroModel()
        {
            librosRepository = new LibrosRepository();
        }

        public string SaveChanges()
        {
            string message = null;

            try
            {
                var libroDataModel = new LibroDTO();

                libroDataModel.IdLibro = idLibro;
                libroDataModel.Nombre = nombre;
                libroDataModel.Autor = autor;
                libroDataModel.AnioPublicacion = anioPublicacion;
                libroDataModel.Categoria = categoria;
                libroDataModel.CantEjemplares = cantEjemplares;
                libroDataModel.EstadoFisico = estadoFisico;
                libroDataModel.Genero = genero;

                switch (State)
                {
                    case EntityState.Added:
                        librosRepository.Add(libroDataModel);
                        message = "Guardado Correctamente";
                        break;
                    case EntityState.Modified:
                        librosRepository.Adit(libroDataModel);
                        message = "Editado Correctamente";
                        break;
                    case EntityState.Deleted:
                        librosRepository.Remove(idLibro);
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

        public List<LibroModel> GetAll()
        {
            var librosDataModel = librosRepository.GetAll();
            listaLibros = new List<LibroModel>();

            foreach (LibroDTO item in librosDataModel)
            {
                listaLibros.Add(new LibroModel
                {
                    IdLibro = item.IdLibro,
                    Nombre = item.Nombre,
                    Autor = item.Autor,
                    AnioPublicacion = item.AnioPublicacion,
                    Categoria = item.Categoria,
                    CantEjemplares = item.CantEjemplares,
                    EstadoFisico = item.EstadoFisico,
                    Genero = item.Genero
                });
            }

            return listaLibros;
        }
    }
}