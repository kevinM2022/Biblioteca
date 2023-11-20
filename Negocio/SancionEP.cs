using Microsoft.AspNetCore.Mvc;
using Datos.Entidades;
using System.Collections.Generic;
using System.Linq;

[Route("api/Sancion")]
[ApiController]
public class SancionController : ControllerBase
{
    private static List<SancionDTO> _sanciones = new List<SancionDTO>();

    // GET api/sancion
    [HttpGet]
    public ActionResult<IEnumerable<SancionDTO>> Get()
    {
        return Ok(_sanciones);
    }

    // GET api/sancion/5
    [HttpGet("{id}")]
    public ActionResult<SancionDTO> Get(int id)
    {
        var sancion = _sanciones.FirstOrDefault(s => s.IdSancion == id);

        if (sancion == null)
        {
            return NotFound();
        }

        return Ok(sancion);
    }

    // POST api/sancion
    [HttpPost]
    public ActionResult Post([FromBody] SancionDTO nuevaSancion)
    {
        nuevaSancion.IdSancion = _sanciones.Count + 1;
        _sanciones.Add(nuevaSancion);

        return CreatedAtAction(nameof(Get), new { id = nuevaSancion.IdSancion }, nuevaSancion);
    }

    // PUT api/sancion/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] SancionDTO sancionActualizada)
    {
        var sancion = _sanciones.FirstOrDefault(s => s.IdSancion == id);

        if (sancion == null)
        {
            return NotFound();
        }

        sancion.Concepto = sancionActualizada.Concepto;
        sancion.Monto = sancionActualizada.Monto;

        return NoContent();
    }

    // DELETE api/sancion/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var sancion = _sanciones.FirstOrDefault(s => s.IdSancion == id);

        if (sancion == null)
        {
            return NotFound();
        }

        _sanciones.Remove(sancion);

        return NoContent();
    }
}
