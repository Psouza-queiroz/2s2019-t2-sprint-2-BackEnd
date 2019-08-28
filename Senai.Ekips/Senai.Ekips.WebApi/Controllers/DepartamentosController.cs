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
    public class DepartamentosController : ControllerBase
    {
        DepartamentoRepository DepartamentoRepository = new DepartamentoRepository();
        [HttpPost]
        public IActionResult Cadastrar(Departamentos Departamentos)
        {
            try
            {
                DepartamentoRepository.Cadastrar(Departamentos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Deu Erro, Tente Novamente, Tente Novamente... " + ex.Message });
            }
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(DepartamentoRepository.Listar());
        }
        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            Departamentos Departamentos = DepartamentoRepository.BuscarPorId(id);
            if (Departamentos == null)
                return null;
            return Ok(Departamentos);
        }


    }
}