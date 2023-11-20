using Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/Prestamo")]
[ApiController]
public class PrestamoController : ControllerBase
{
    private static List<PrestamoDTO> _prestamos = new List<PrestamoDTO>();

    // GET api/prestamo
    [HttpGet]
    public ActionResult<IEnumerable<PrestamoDTO>> Get()
    {
        return Ok(_prestamos);
    }

    // GET api/prestamo/5
    [HttpGet("{id}")]
    public ActionResult<PrestamoDTO> Get(int id)
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
    public ActionResult Post([FromBody] PrestamoDTO nuevoPrestamo)
    {
        nuevoPrestamo.IdPrestamo = _prestamos.Count + 1;
        _prestamos.Add(nuevoPrestamo);

        return CreatedAtAction(nameof(Get), new { id = nuevoPrestamo.IdPrestamo }, nuevoPrestamo);
    }

    // PUT api/prestamo/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] PrestamoDTO prestamoActualizado)
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
