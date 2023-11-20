using Microsoft.AspNetCore.Mvc;
using Datos.Entidades;
using System;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    // Simulación de datos (puedes reemplazar esto con una base de datos u otro almacenamiento)
    private static List<UsuarioDTO> _usuarios = new List<UsuarioDTO>
    {
        new UsuarioDTO { IdUsuario = 1, Nombre = "John", Apellido = "Doe", Telefono = "123456789", Correo = "john.doe@example.com", Rol = "Usuario", Direccion = "123 Main St" },
        new UsuarioDTO { IdUsuario = 2, Nombre = "Jane", Apellido = "Doe", Telefono = "987654321", Correo = "jane.doe@example.com", Rol = "Admin", Direccion = "456 Broad St" }
    };

    // GET api/usuario
    [HttpGet]
    public ActionResult<IEnumerable<UsuarioDTO>> Get()
    {
        return Ok(_usuarios);
    }

    // GET api/usuario/5
    [HttpGet("{id}")]
    public ActionResult<UsuarioDTO> Get(int id)
    {
        var usuario = _usuarios.Find(u => u.IdUsuario == id);
        if (usuario == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el usuario
        }
        return Ok(usuario);
    }

    // POST api/usuario
    [HttpPost]
    public ActionResult<UsuarioDTO> Post([FromBody] UsuarioDTO usuario)
    {
        // Simplemente agregamos el usuario a la lista (en un escenario real, aquí podrías agregarlo a tu base de datos)
        usuario.IdUsuario = _usuarios.Count + 1;
        _usuarios.Add(usuario);

        // Devuelve un código 201 (Created) y el usuario recién creado
        return CreatedAtAction(nameof(Get), new { id = usuario.IdUsuario }, usuario);
    }

    // PUT api/usuario/5
    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UsuarioDTO usuario)
    {
        var existingUsuario = _usuarios.Find(u => u.IdUsuario == id);
        if (existingUsuario == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el usuario
        }

        // Actualiza las propiedades del usuario existente
        existingUsuario.Nombre = usuario.Nombre;
        existingUsuario.Apellido = usuario.Apellido;
        existingUsuario.Telefono = usuario.Telefono;
        existingUsuario.Correo = usuario.Correo;
        existingUsuario.Rol = usuario.Rol;
        existingUsuario.Direccion = usuario.Direccion;

        return NoContent(); // Devuelve un código 204 (No Content) indicando que la operación fue exitosa
    }

    // DELETE api/usuario/5
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = _usuarios.Find(u => u.IdUsuario == id);
        if (usuario == null)
        {
            return NotFound(); // Devuelve un código 404 si no se encuentra el usuario
        }

        _usuarios.Remove(usuario);

        return NoContent(); // Devuelve un código 204 (No Content) indicando que la operación fue exitosa
    }
}
