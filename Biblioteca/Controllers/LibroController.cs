using Biblioteca.Entidades;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/Libro")]
    public class LibroController : Controller
    {
        private readonly ILogger<LibroController> logger;
        private readonly LibroEP libro;
        private readonly LibroDTO libroDTO;

        public LibroController(ILogger<LibroController> logger, LibroEP libro,LibroDTO libroDTO)
        {
            this.logger = logger;
            this.libro = libro;
            this.libroDTO = libroDTO;
        }

        [HttpGet]
        public async Task<ActionResult<List<LibroDTO>>> Get()
        {
            return await libro.Get();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] LibroCDTO libroCDTO)
        {
            return await libro.Post(libroCDTO);
        }
    }
}