using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Entidades
{
    //Una entidad por cada tabla de sql, contendra los atributos de las tablas
    public class LibroDTO
    {
        public int IdLibro { get; set; }
        public string Nombre { get; set; }
        public string Autor { get; set; }

        public string AnioPublicacion { get; set; }

        public string Categoria { get; set; }

        public int CantEjemplares { get; set; }

        public string EstadoFisico { get; set; }

        public string Genero { get; set; }
    }
}
