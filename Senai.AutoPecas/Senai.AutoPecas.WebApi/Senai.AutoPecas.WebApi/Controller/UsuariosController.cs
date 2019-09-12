using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interface;
using Senai.AutoPecas.WebApi.Repositories;
using Senai.AutoPecas.WebApi.ViewModels;

namespace Senai.AutoPecas.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }
       [HttpPost]
        public IActionResult Cadastrar(Usuarios usuarios)
        {
            UsuarioRepository.Cadastrar(usuarios);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UsuarioRepository.Deletar(id);
            return Ok();
        }
    }
} 