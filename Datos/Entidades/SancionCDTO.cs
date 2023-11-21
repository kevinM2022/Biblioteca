using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{

    public class Sancion
    {
        [Required]
        public int IdSancion { get; set; }

        [StringLength(maximumLength: 100)]
        public string Concepto { get; set; }


        [Required]
        [StringLength(maximumLength: 20)]
        public string Monto { get; set; }

    }
}
