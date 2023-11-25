using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Datos.Entidades
{

    public class UsuarioCDTO
    {

        [Required]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(maximumLength: 120)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(maximumLength: 120)]
        public string Apellido { get; set; }

        [Required]
        [StringLength(maximumLength: 40)]
        public string Telefono {get;set;}

        [Required]
        [StringLength(maximumLength: 120)]
        public string Correo {get;set;}

        [Required]
        [StringLength(maximumLength: 40)]
        public string Rol {get;set;}

        [Required]
        [StringLength(maximumLength: 120)]
        public string Direccion {get;set;}

        [Required]
        [StringLength(maximumLength:100)]
        public string Usuario {get;set;}

        [Required]
        [StringLength(maximumLength:150)]
        public string Password {get;set;}

    }
}
