using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interface;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private ICategoriaRepository CategoriaRepository { get; set; }

        public CategoriasController()
        {
            CategoriaRepository = new CategoriaRepository();
        }
        [Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            //try
            //{
                //int IdUsuario = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type == JwtRegisteredClaimNames.Jti).Value);
               // categoria.IdCategoria = IdUsuario;
                CategoriaRepository.Cadastrar(categoria);
                return Ok();
            //}
           // catch (System.Exception ex)
           // {
            //    return BadRequest(new { mensagem = ex.Message });
          //  }
        }
        [Authorize(Roles = "administrador")]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias categorias = CategoriaRepository.BuscarPorId(id);
            if (categorias == null)
                return null;
            return Ok(categorias);
        }
        [Authorize(Roles = "administrador")]
        [HttpPut("{Id}")]
        public IActionResult Atualizar(Categorias categorias , int id)
        {
            Categorias AtualizarCategoria = CategoriaRepository.BuscarPorId(id);
            if (AtualizarCategoria == null)
                return NotFound();
            categorias.IdCategoria = id;
            CategoriaRepository.Atualizar(categorias);
            return Ok();
        }
    }
}