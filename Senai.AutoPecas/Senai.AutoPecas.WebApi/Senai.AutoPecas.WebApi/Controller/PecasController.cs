using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interface;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PecasController : ControllerBase
    {
        private IPecasRepository pecaRepository { get; set; }

        public PecasController()
        {
            pecaRepository = new PecaRepository();
        }


        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(pecaRepository.Listar());
        }


        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            pecaRepository.Deletar(id);
            return Ok();
        }

        [Authorize(Roles = "Fornecedor")]
        [HttpPost]
        public IActionResult Cadastrar(Pecas pecas)
        {
            pecaRepository.Cadastrar(pecas);
            return Ok();
        }

      
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Pecas pecas = pecaRepository.BuscarPorId(id);
            if (pecas == null)
                return null;
            return Ok(pecas);
        }
        [Authorize(Roles = "Fornecedor")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(Pecas pecas, int id)
        {
            Pecas Atualizarpecas = pecaRepository.BuscarPorId(id);
            if (Atualizarpecas == null)
                return NotFound();
            pecas.IdPeca = id;
            pecaRepository.Atualizar(pecas);
            return Ok();

        }

    }
}