using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        FuncionarioRepository funcionarioRepository = new FuncionarioRepository();

        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionarios)
        {
            //  try
            //{
            funcionarioRepository.Cadastrar(funcionarios);
            return Ok();
            //}
            //catch (Exception ex)
            //{
            //  return BadRequest(new { mensagem = "Deu Erro, Tente Novamente, Tente Novamente... " + ex.Message });
            //}
        }
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(funcionarioRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionarios funcionarios = funcionarioRepository.BuscarPorId(id);
            if (funcionarios == null)
                return null;
            return Ok(funcionarios);
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Funcionarios funcionarios, int id)
        {
            //try
            //{
            Funcionarios AtualizarFuncionario = funcionarioRepository.BuscarPorId(id);

            if (AtualizarFuncionario == null)
            {
                return NotFound();
            }
            funcionarios.IdFuncionario = id;
            funcionarioRepository.Atualizar(funcionarios);
            return Ok();
            //    }
            //    catch (Exception ex)
            //    {

            //        return BadRequest(new { mensagem = "Deu Erro, Confere os erro ai e Tente Novamente, Tente Novamente... " + ex.Message });
            //    }
            //}

        }
        [HttpDelete("{id}")]
        public IActionResult Deletar (int id)
        {
            funcionarioRepository.Deletar(id);
            return Ok();
        }
    }
}
