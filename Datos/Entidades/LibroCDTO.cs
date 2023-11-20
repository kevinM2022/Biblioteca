using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    public class LibroCDTO
    {
        [required]
        public int IdLibro { get; set; }

        [required]
        [StringLength(maximumLength: 60)]
        public string Nombre { get; set; }

        [required]
        [StringLength(maximumLength: 60)]
        public string Autor { get; set; }

        [required]
        [StringLength(maximumLength: 20)]
        public string AnioPublicacion { get; set; }

        [required]
        [StringLength(maximumLength: 40)]
        public string Categoria { get; set; }

        [required]
        [StringLength(maximumLength: 10)]
        public string CantEjemplares { get; set; }

        [required]
        [StringLength(maximumLength: 20)]
        public string EstadoFisico { get; set; }

        [required]
        [StringLength(maximumLength: 40)]
        public string Genero { get; set; }
    }
}
