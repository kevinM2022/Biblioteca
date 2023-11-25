using Microsoft.AspNetCore.Mvc;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Globalization;

[Route("api/[controller]")]
[ApiController]
public class PrestamoController : ControllerBase
{
    // Simulación de datos (puedes reemplazar esto con una base de datos u otro almacenamiento)
    private static List<PrestamoDTO> _prestamos = new List<PrestamoDTO>
    {
new PrestamoDTO { IdPrestamo = 1, CantidadLibros = "2", EstadoPrestamo = "Activo", FechaPrestamo = new DateTime(2023, 1, 1), Devolucion = DateTime.ParseExact("01-02-2023", "dd-MM-yyyy", CultureInfo.InvariantCulture) },
new PrestamoDTO { IdPrestamo = 2, CantidadLibros = "3", EstadoPrestamo = "Inactivo", FechaPrestamo = new DateTime(2023, 3, 1), Devolucion = DateTime.ParseExact("01-04-2023", "dd-MM-yyyy", CultureInfo.InvariantCulture) }

    };

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
        var prestamo = _prestamos.Find(p => p.IdPrestamo == id);
        if (prestamo == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el préstamo
        }
        return Ok(prestamo);
    }

    // POST api/prestamo
    [HttpPost]
    public ActionResult<PrestamoDTO> Post([FromBody] PrestamoDTO prestamo)
    {
        // Simplemente agregamos el préstamo a la lista (en un escenario real, aquí podrías agregarlo a tu base de datos)
        prestamo.IdPrestamo = _prestamos.Count + 1;
        _prestamos.Add(prestamo);

        // Devuelve un código 201 (Created) y el préstamo recién creado
        return CreatedAtAction(nameof(Get), new { id = prestamo.IdPrestamo }, prestamo);
    }

    // PUT api/prestamo/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] PrestamoDTO prestamo)
    {
        var existingPrestamo = _prestamos.Find(p => p.IdPrestamo == id);
        if (existingPrestamo == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el préstamo
        }

        // Actualiza las propiedades del préstamo existente
        existingPrestamo.CantidadLibros = prestamo.CantidadLibros;
        existingPrestamo.EstadoPrestamo = prestamo.EstadoPrestamo;
        existingPrestamo.FechaPrestamo = prestamo.FechaPrestamo;
        existingPrestamo.Devolucion = prestamo.Devolucion;

        return NoContent(); // Devuelve un código 204 (No Content) indicando que la operación fue exitosa
    }

    // DELETE api/prestamo/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var prestamo = _prestamos.Find(p => p.IdPrestamo == id);
        if (prestamo == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el préstamo
        }

        _prestamos.Remove(prestamo);

        return NoContent(); // Devuelve un código 204 (No Content) indicando que la operación fue exitosa
    }
}
