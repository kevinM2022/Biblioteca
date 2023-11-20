using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    //Una entidad por cada tabla de sql, contendra los atributos de las tablas
    public class SancionDTO
    {
        public int IdSancion { get; set; }
        public string Concepto { get; set; }
        public string Monto { get; set; }

    }
}
