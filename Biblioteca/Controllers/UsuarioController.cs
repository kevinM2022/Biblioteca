﻿using Biblioteca.Entidades;
using Domain;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers
{
    [Route("api/Usuario")]
    public class UsuarioController : Controller
    {
        private readonly ILogger<UsuarioController> logger;
        private readonly UsuarioEP usuario;
        private readonly UsuarioDTO usuarioDTO;

        public UsuarioController(ILogger<UsuarioController> logger, UsuarioEP usuario, UsuarioDTO usuarioDTO)
        {
            this.logger = logger;
            this.usuario = usuario;
            this.usuarioDTO = usuarioDTO;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioDTO>>> Get()
        {
            return await usuario.Get();
        }

        [HttpPost]
        public async Task<ActionResult<string>> Post([FromBody] UsuarioCDTO usuarioCDTO)
        {
            return await usuario.Post(usuarioCDTO);
        }
    }
}