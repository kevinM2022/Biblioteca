﻿using Datos.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class LibroController : ControllerBase
{
    // Simulación de datos (puedes reemplazar esto con una base de datos u otro almacenamiento)
    private static List<LibroDTO> _libros = new List<LibroDTO>
    {
        new LibroDTO { IdLibro = 1, Nombre = "El señor de los anillos", Autor = "J.R.R. Tolkien", AnioPublicacion = "1954", Categoria = "Fantasía", CantEjemplares = "100", EstadoFisico = "Bueno", Genero = "Épica" },
        new LibroDTO { IdLibro = 2, Nombre = "Cien años de soledad", Autor = "Gabriel García Márquez", AnioPublicacion = "1967", Categoria = "Realismo mágico", CantEjemplares = "75", EstadoFisico = "Regular", Genero = "Novela" }
    };

    // GET api/libro
    [HttpGet]
    public ActionResult<IEnumerable<LibroDTO>> Get()
    {
        return Ok(_libros);
    }

    // GET api/libro/5
    [HttpGet("{id}")]
    public ActionResult<LibroDTO> Get(int id)
    {
        var libro = _libros.Find(l => l.IdLibro == id);
        if (libro == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el libro
        }
        return Ok(libro);
    }

    // POST api/libro
    [HttpPost]
    public ActionResult<LibroDTO> Post([FromBody] LibroDTO libro)
    {
        // Simplemente agregamos el libro a la lista (en un escenario real, aquí podrías agregarlo a tu base de datos)
        libro.IdLibro = _libros.Count + 1;
        _libros.Add(libro);

        // Devuelve un código 201 (Created) y el libro recién creado
        return CreatedAtAction(nameof(Get), new { id = libro.IdLibro }, libro);
    }

    // PUT api/libro/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] LibroDTO libro)
    {
        var existingLibro = _libros.Find(l => l.IdLibro == id);
        if (existingLibro == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el libro
        }

        // Actualiza las propiedades del libro existente
        existingLibro.Nombre = libro.Nombre;
        existingLibro.Autor = libro.Autor;
        existingLibro.AnioPublicacion = libro.AnioPublicacion;
        existingLibro.Categoria = libro.Categoria;
        existingLibro.CantEjemplares = libro.CantEjemplares;
        existingLibro.EstadoFisico = libro.EstadoFisico;
        existingLibro.Genero = libro.Genero;

        return NoContent(); // Devuelve un código 204 (No Content) indicando que la operación fue exitosa
    }

    // DELETE api/libro/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var libro = _libros.Find(l => l.IdLibro == id);
        if (libro == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el libro
        }

        _libros.Remove(libro);

        return NoContent(); // Devuelve un código 204 (No Content) indicando que la operación fue exitosa
    }
}
