using Biblioteca.Entidades;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/Sancion")]
    public class SancionController : Controller
    {
        private readonly ILogger<SancionController> logger;
        private readonly SancionEP sancion;
        private readonly SancionDTO sancionDTO;

        public SancionController(ILogger<SancionController> logger, SancionEP sancion,SancionDTO sancionDTO)
        {
            this.logger = logger;
            this.sancion = sancion;
            this.sancionDTO = sancionDTO;
        }

        [HttpGet]
        public async Task<ActionResult<List<SancionDTO>>> Get()
        {
            return await sancion.Get();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] SancionCDTO sancionCDTO)
        {
            return await sancion.Post(sancionCDTO);
        }
    }
}