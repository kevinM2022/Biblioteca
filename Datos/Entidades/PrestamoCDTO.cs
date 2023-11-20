using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{

    public class PrestamoCDTO
    {
        [required]
        public int IdPrestamo { get; set; }

        [required]
        [StringLength(maximumLength: 20)]
        public string CantidadLibros { get; set; }

        [required]
        [StringLength(maximumLength: 20)]
        public string EstadoPrestamo { get; set; }

        [StringLength(maximumLength: 20)]
        public string FechaPrestamo { get; set; }

        [StringLength(maximumLength: 20)]
        public string Devolucion { get; set; }
    }
}