using Microsoft.AspNetCore.Mvc;
using Datos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

[Route("api/[controller]")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private static List<UsuarioDTO> _usuarios = new List<UsuarioDTO>
    {
        new UsuarioDTO { IdUsuario = 1, Nombre = "John", Apellido = "Doe", Telefono = "123456789", Correo = "john.doe@example.com", Rol = "Usuario", Direccion = "123 Main St", User = "john_user", Password = "password123" },
        new UsuarioDTO { IdUsuario = 2, Nombre = "Jane", Apellido = "Doe", Telefono = "987654321", Correo = "jane.doe@example.com", Rol = "Admin", Direccion = "456 Broad St", User = "jane_user", Password = "admin123" }
    };

    [HttpGet]
    public ActionResult<IEnumerable<UsuarioDTO>> Get()
    {
        return Ok(_usuarios);
    }

    [HttpGet("{id}")]
    public ActionResult<UsuarioDTO> Get(int id)
    {
        var usuario = _usuarios.Find(u => u.IdUsuario == id);
        if (usuario == null)
        {
            return NotFound();
        }

        return Ok(usuario);
    }

    [HttpPost]
    public ActionResult<UsuarioDTO> Post([FromBody] UsuarioDTO usuario)
    {
        usuario.IdUsuario = _usuarios.Count + 1;
        _usuarios.Add(usuario);

        return CreatedAtAction(nameof(Get), new { id = usuario.IdUsuario }, usuario);
    }

    [HttpPut("{id}")]
    public IActionResult Put(int id, [FromBody] UsuarioDTO usuario)
    {
        var existingUsuario = _usuarios.Find(u => u.IdUsuario == id);
        if (existingUsuario == null)
        {
            return NotFound();
        }

        existingUsuario.Nombre = usuario.Nombre;
        existingUsuario.Apellido = usuario.Apellido;
        existingUsuario.Telefono = usuario.Telefono;
        existingUsuario.Correo = usuario.Correo;
        existingUsuario.Rol = usuario.Rol;
        existingUsuario.Direccion = usuario.Direccion;
        existingUsuario.User = usuario.User;
        existingUsuario.Password = usuario.Password;

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var usuario = _usuarios.Find(u => u.IdUsuario == id);
        if (usuario == null)
        {
            return NotFound();
        }

        _usuarios.Remove(usuario);

        return NoContent();
    }
}
