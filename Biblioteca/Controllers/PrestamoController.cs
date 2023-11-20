using Biblioteca.Entidades;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/Prestamo")]
    public class PrestamoController : Controller
    {
        private readonly ILogger<PrestamoController> logger;
        private readonly PrestamoEP prestamo;
        private readonly PrestamoDTO prestamoDTO;

        public PrestamoController(ILogger<PrestamoController> logger, PrestamoEP prestamo,PrestamoDTO prestamoDTO)
        {
            this.logger = logger;
            this.prestamo = prestamo;
            this.prestamoDTO = prestamoDTO;
        }

        [HttpGet]
        public async Task<ActionResult<List<PrestamoDTO>>> Get()
        {
            return await prestamo.Get();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] PrestamoCDTO prestamoCDTO)
        {
            return await prestamo.Post(prestamoCDTO);
        }
    }
}