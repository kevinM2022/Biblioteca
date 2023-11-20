using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/Sancion")]
[ApiController]
public class SancionController : ControllerBase
{
    private static List<Sancion> _sanciones = new List<Sancion>();

    // GET api/sancion
    [HttpGet]
    public ActionResult<IEnumerable<Sancion>> Get()
    {
        return Ok(_sanciones);
    }

    // GET api/sancion/5
    [HttpGet("{id}")]
    public ActionResult<Sancion> Get(int id)
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
    public ActionResult Post([FromBody] Sancion nuevaSancion)
    {
        nuevaSancion.IdSancion = _sanciones.Count + 1;
        _sanciones.Add(nuevaSancion);

        return CreatedAtAction(nameof(Get), new { id = nuevaSancion.IdSancion }, nuevaSancion);
    }

    // PUT api/sancion/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Sancion sancionActualizada)
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
