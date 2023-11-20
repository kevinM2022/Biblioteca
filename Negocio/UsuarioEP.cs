using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

[Route("api/Usuario")]
[ApiController]
public class UsuarioController : ControllerBase
{
    private static List<Usuario> _usuarios = new List<Usuario>();

    // GET api/usuario
    [HttpGet]
    public ActionResult<IEnumerable<Usuario>> Get()
    {
        return Ok(_usuarios);
    }

    // GET api/usuario/5
    [HttpGet("{id}")]
    public ActionResult<Usuario> Get(int id)
    {
        var usuario = _usuarios.FirstOrDefault(u => u.IdUsuario == id);

        if (usuario == null)
        {
            return NotFound();
        }

        return Ok(usuario);
    }

    // POST api/usuario
    [HttpPost]
    public ActionResult Post([FromBody] Usuario nuevoUsuario)
    {
        nuevoUsuario.IdUsuario = _usuarios.Count + 1;
        _usuarios.Add(nuevoUsuario);

        return CreatedAtAction(nameof(Get), new { id = nuevoUsuario.IdUsuario }, nuevoUsuario);
    }

    // PUT api/usuario/5
    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] Usuario usuarioActualizado)
    {
        var usuario = _usuarios.FirstOrDefault(u => u.IdUsuario == id);

        if (usuario == null)
        {
            return NotFound();
        }

        usuario.Nombre = usuarioActualizado.Nombre;
        usuario.Apellido = usuarioActualizado.Apellido;
        usuario.Telefono = usuarioActualizado.Telefono;
        usuario.Correo = usuarioActualizado.Correo;
        usuario.Rol = usuarioActualizado.Rol;
        usuario.Direccion = usuarioActualizado.Direccion;

        return NoContent();
    }

    // DELETE api/usuario/5
    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        var usuario = _usuarios.FirstOrDefault(u => u.IdUsuario == id);

        if (usuario == null)
        {
            return NotFound();
        }

        _usuarios.Remove(usuario);

        return NoContent();
    }
}
