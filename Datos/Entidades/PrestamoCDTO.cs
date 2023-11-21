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
        public int CantidadLibros { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string EstadoPrestamo { get; set; }

        [Required]
        public DateOnly FechaPrestamo { get; set; }

        [Required]
        public DateOnly Devolucion { get; set; }
    }
}
