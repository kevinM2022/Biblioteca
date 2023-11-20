using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Datos.Entidades
{
    public class LibroCDTO
    {
        [Required]
        public int IdLibro { get; set; }

        [Required]
        [StringLength(maximumLength: 60)]
        public string Nombre { get; set; }

        [Required]
        [StringLength(maximumLength: 60)]
        public string Autor { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string AnioPublicacion { get; set; }

        [Required]
        [StringLength(maximumLength: 40)]
        public string Categoria { get; set; }

        [Required]
        [StringLength(maximumLength: 10)]
        public string CantEjemplares { get; set; }

        [Required]
        [StringLength(maximumLength: 20)]
        public string EstadoFisico { get; set; }

        [Required]
        [StringLength(maximumLength: 40)]
        public string Genero { get; set; }
    }
}
