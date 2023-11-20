using Microsoft.AspNetCore.Mvc;
using Datos.Entidades;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class SancionController : ControllerBase
{
    // Simulación de datos (puedes reemplazar esto con una base de datos u otro almacenamiento)
    private static List<SancionDTO> _sanciones = new List<SancionDTO>
    {
        new SancionDTO { IdSancion = 1, Concepto = "Falta de pago", Monto = "$50.00" },
        new SancionDTO { IdSancion = 2, Concepto = "Violación de políticas", Monto = "$100.00" }
    };

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
        var sancion = _sanciones.Find(s => s.IdSancion == id);
        if (sancion == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra la sanción
        }
        return Ok(sancion);
    }

    // POST api/sancion
    [HttpPost]
    public ActionResult<SancionDTO> Post([FromBody] SancionDTO sancion)
    {
        // Simplemente agregamos la sanción a la lista (en un escenario real, aquí podrías agregarla a tu base de datos)
        sancion.IdSancion = _sanciones.Count + 1;
        _sanciones.Add(sancion);

        // Devuelve un código 201 (Created) y la sanción recién creada
        return CreatedAtAction(nameof(Get), new { id = sancion.IdSancion }, sancion);
    }

    // PUT api/sancion/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] SancionDTO sancion)
    {
        var existingSancion = _sanciones.Find(s => s.IdSancion == id);
        if (existingSancion == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra la sanción
        }

        // Actualiza las propiedades de la sanción existente
        existingSancion.Concepto = sancion.Concepto;
        existingSancion.Monto = sancion.Monto;

        return NoContent(); // Devuelve un código 204 (No Content) indicando que la operación fue exitosa
    }

    // DELETE api/sancion/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var sancion = _sanciones.Find(s => s.IdSancion == id);
        if (sancion == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra la sanción
        }

        _sanciones.Remove(sancion);

        return NoContent(); // Devuelve un código 204 (No Content) indicando que la operación fue exitosa
    }
}
