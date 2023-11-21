using DataAccess.Contracts;
using Datos.Entidades;
using DataAccess.Repositories;
using Datos.Repositorios;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class UsuarioModel
    {
        private int idUsuario;
        private string nombre;
        private string apellido;
        private string telefono;
        private string correo;
        private string rol;
        private string direccion;

        private UsuarioRepository usuarioRepository;
        private List<UsuarioModel> listaUsuarios;

        public EntityState State { private get; set; }

        public int IdUsuario { get => idUsuario; set => idUsuario = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Rol { get => rol; set => rol = value; }
        public string Direccion { get => direccion; set => direccion = value; }

        public UsuarioModel()
        {
            usuarioRepository = new UsuarioRepository();
        }

        public string SaveChanges()
        {
            string message = null;

            try
            {
                var usuarioDataModel = new UsuarioDTO();

                usuarioDataModel.IdUsuario = idUsuario;
                usuarioDataModel.Nombre = nombre;
                usuarioDataModel.Apellido = apellido;
                usuarioDataModel.Telefono = telefono;
                usuarioDataModel.Correo = correo;
                usuarioDataModel.Rol = rol;
                usuarioDataModel.Direccion = direccion;

                switch (State)
                {
                    case EntityState.Added:
                        usuarioRepository.Add(usuarioDataModel);
                        message = "Guardado Correctamente";
                        break;
                    case EntityState.Modified:
                        usuarioRepository.Adit(usuarioDataModel);
                        message = "Editado Correctamente";
                        break;
                    case EntityState.Deleted:
                        usuarioRepository.Remove(idUsuario);
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

        public List<UsuarioModel> GetAll()
        {
            var usuariosDataModel = usuarioRepository.GetAll();
            listaUsuarios = new List<UsuarioModel>();

            foreach (UsuarioDTO item in usuariosDataModel)
            {
                listaUsuarios.Add(new UsuarioModel
                {
                    IdUsuario = item.IdUsuario,
                    Nombre = item.Nombre,
                    Apellido = item.Apellido,
                    Telefono = item.Telefono,
                    Correo = item.Correo,
                    Rol = item.Rol,
                    Direccion = item.Direccion
                });
            }

            return listaUsuarios;
        }
    }
}
