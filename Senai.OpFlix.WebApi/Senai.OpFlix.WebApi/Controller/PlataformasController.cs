using System;
using System.Collections.Generic;
using System.Linq;
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
    [ApiController]
    public class PlataformasController : ControllerBase
    {
        private IPlataformaRepository PlataformaRepository{ get; set; }

        public PlataformasController()
        {
            PlataformaRepository = new PlataformaRepository();
        }

        [Authorize(Roles = "administrador")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformaRepository.Listar());
        }

        [Authorize(Roles = "administrador")]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int id)
        {
            Plataforma plataforma = PlataformaRepository.BuscarPorId(id);
            if (plataforma == null)
                return null;
            return Ok(plataforma);
        }
        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Plataforma plataforma)
        {
            PlataformaRepository.Cadastrar(plataforma);
            return Ok();
        }
        [Authorize(Roles = "administrador")]
        [HttpPut("{Id}")]
        public IActionResult Atualizar (Plataforma plataforma , int id)
        {
            Plataforma AtualizarPlataforma = PlataformaRepository.BuscarPorId(id);
            if (AtualizarPlataforma == null)
                return NotFound();
            plataforma.IdPlataforma = id;
            PlataformaRepository.atualizar(plataforma);
            return Ok();
        }

    }
}