using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

[Route("api/Libro")]
[ApiController]
public class LibroController : ControllerBase
{
    private static List<Libro> _libros = new List<Libro>();

    // GET api/libro
    [HttpGet]
    public ActionResult<IEnumerable<Libro>> Get()
    {
        return Ok(_libros);
    }

    // GET api/libro/5
    [HttpGet("{id}")]
    public ActionResult<Libro> Get(int id)
    {
        var libro = _libros.FirstOrDefault(l => l.IdLibro == id);

        if (libro == null)
        {
            return NotFound();
        }

        return Ok(libro);
    }

    // POST api/libro
    [HttpPost]
    public ActionResult Post([FromBody] Libro nuevoLibro)
    {
        nuevoLibro.IdLibro = _libros.Count + 1;
        _libros.Add(nuevoLibro);

        return CreatedAtAction(nameof(Get), new { id = nuevoLibro.IdLibro }, nuevoLibro);
    }

    // PUT api/libro/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Libro libroActualizado)
    {
        var libro = _libros.FirstOrDefault(l => l.IdLibro == id);

        if (libro == null)
        {
            return NotFound();
        }

        libro.Nombre = libroActualizado.Nombre;
        libro.Autor = libroActualizado.Autor;
        libro.AnioPublicacion = libroActualizado.AnioPublicacion;
        libro.Categoria = libroActualizado.Categoria;
        libro.CantEjemplares = libroActualizado.CantEjemplares;
        libro.EstadoFisico = libroActualizado.EstadoFisico;
        libro.Genero = libroActualizado.Genero;

        return NoContent();
    }

    // DELETE api/libro/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var libro = _libros.FirstOrDefault(l => l.IdLibro == id);

        if (libro == null)
        {
            return NotFound();
        }

        _libros.Remove(libro);

        return NoContent();
    }
}
