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
    [Produces("application/json")]
    [ApiController]
    public class LancamentosController : ControllerBase
    {
        private ILancamentoRepository LancamentoRepository { get; set;}
        
        public LancamentosController()
        {
            LancamentoRepository = new LancamentoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentoRepository.Listar());
        }

        [Authorize(Roles = "administrador")]
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int id)
        {
            Lancamentos lancamentos = LancamentoRepository.BuscarPorId(id);
            if (lancamentos == null)
                return null;
            return Ok(lancamentos);
        }

        [Authorize(Roles = "administrador")]
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamentos)
        {
            LancamentoRepository.Cadastrar(lancamentos);
            return Ok();
        }

        [Authorize(Roles = "administrador")]
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            LancamentoRepository.Deletar(id);
            return Ok();
        }
        [Authorize(Roles = "administrador")]
        [HttpPut("{id}")]
        public IActionResult Atualizar (Lancamentos lancamentos , int id)
        {
            Lancamentos AtualizarLancamento = LancamentoRepository.BuscarPorId(id);
            if (AtualizarLancamento == null)
                return NotFound();
            lancamentos.IdLancamento = id;
            LancamentoRepository.Atualizar(lancamentos);
            return Ok();

        }
    }
}