using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        UsuarioRepository usuarioRepository = new UsuarioRepository();
        
        [HttpGet]
        public IActionResult Listar(Usuarios usuario)
        {
            return Ok(usuarioRepository.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar (Usuarios usuario)
        {
            return Ok();
        }
    }
}