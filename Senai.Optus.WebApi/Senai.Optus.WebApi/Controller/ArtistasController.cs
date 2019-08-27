using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();
        [Authorize]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ArtistaRepository.Listar());
        }
        [HttpPost]
        public IActionResult Cadastrar (Artistas artistas)
        {
            try
            {
                ArtistaRepository.Cadastrar(artistas);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "eita, erro: " + ex.Message });
            }
        }
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Artistas artistas = ArtistaRepository.BuscarPorId(id);
            if (artistas == null)
                return NotFound();
            return Ok(artistas);              
        }

    }
}