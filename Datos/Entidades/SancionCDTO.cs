using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{

    public class Sancion
    {
        [required]
        public int IdSancion { get; set; }

        [StringLength(maximumLength: 100)]
        public string Concepto { get; set; }


        [required]
        [StringLength(maximumLength: 20)]
        public string Monto { get; set; }

    }
}
