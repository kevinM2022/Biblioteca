using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{

    public class Prestamo
    {
        public int IdPrestamo { get; set; }
        public string CantidadLibros { get; set; }
        public string EstadoPrestamo { get; set; }
        public string FechaPrestamo { get; set; }
        public string Devolucion { get; set; }
    }
}