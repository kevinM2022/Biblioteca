using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class PrestamoCDTO
    {
        [Required]
        public int IdPrestamo { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string CantidadLibros { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string EstadoPrestamo { get; set; }

        [StringLength(maximumLength: 20)]
        public string FechaPrestamo { get; set; }

        [StringLength(maximumLength: 20)]
        public string Devolucion { get; set; }
    }
}
