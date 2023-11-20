using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{

    public class UsuarioCDTO
    {

        [required]
        public int IdUsuario { get; set; }

        [required]
        [StringLength(maximumLength: 120)]
        public string Nombre { get; set; }

        [required]
        [StringLength(maximumLength: 120)]
        public string Apellido { get; set; }

        [required]
        [StringLength(maximumLength: 40)]
        public string Telefono {get;set;}

        [required]
        [StringLength(maximumLength: 120)]
        public string Correo {get;set;}

        [required]
        [StringLength(maximumLength: 40)]
        public string Rol {get;set;}

        [required]
        [StringLength(maximumLength: 120)]
        public string Direccion {get;set;}

    }
}
