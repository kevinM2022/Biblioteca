using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/Prestamo")]
[ApiController]
public class PrestamoController : ControllerBase
{
    private static List<Prestamo> _prestamos = new List<Prestamo>();

    // GET api/prestamo
    [HttpGet]
    public ActionResult<IEnumerable<Prestamo>> Get()
    {
        return Ok(_prestamos);
    }

    // GET api/prestamo/5
    [HttpGet("{id}")]
    public ActionResult<Prestamo> Get(int id)
    {
        var prestamo = _prestamos.FirstOrDefault(p => p.IdPrestamo == id);

        if (prestamo == null)
        {
            return NotFound();
        }

        return Ok(prestamo);
    }

    // POST api/prestamo
    [HttpPost]
    public ActionResult Post([FromBody] Prestamo nuevoPrestamo)
    {
        nuevoPrestamo.IdPrestamo = _prestamos.Count + 1;
        _prestamos.Add(nuevoPrestamo);

        return CreatedAtAction(nameof(Get), new { id = nuevoPrestamo.IdPrestamo }, nuevoPrestamo);
    }

    // PUT api/prestamo/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Prestamo prestamoActualizado)
    {
        var prestamo = _prestamos.FirstOrDefault(p => p.IdPrestamo == id);

        if (prestamo == null)
        {
            return NotFound();
        }

        prestamo.CantidadLibros = prestamoActualizado.CantidadLibros;
        prestamo.EstadoPrestamo = prestamoActualizado.EstadoPrestamo;
        prestamo.FechaPrestamo = prestamoActualizado.FechaPrestamo;
        prestamo.Devolucion = prestamoActualizado.Devolucion;

        return NoContent();
    }

    // DELETE api/prestamo/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var prestamo = _prestamos.FirstOrDefault(p => p.IdPrestamo == id);

        if (prestamo == null)
        {
            return NotFound();
        }

        _prestamos.Remove(prestamo);

        return NoContent();
    }
}
