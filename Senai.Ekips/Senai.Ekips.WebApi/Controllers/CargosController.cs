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
    public class CargosController : ControllerBase
    {
        CargoRepository CargoRepository = new CargoRepository();

        [HttpPost]
        public IActionResult Cadastrar(Cargos cargos)
        {
            try
            {
                CargoRepository.Cadastrar(cargos);
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
            return Ok(CargoRepository.Listar());
        }
        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {
            Cargos cargos = CargoRepository.BuscarPorId(id);
            if (cargos == null)
                return null;
            return Ok(cargos);
        }
        [HttpPut("{id}")]
        public IActionResult Atualizar (Cargos cargos, int id)
        {
            try
            {
                Cargos AtualizarCargo = CargoRepository.BuscarPorId(id);

                if (AtualizarCargo == null)
                    return NotFound();
                cargos.IdCargo = id;
                CargoRepository.Atualizar(cargos);
                return Ok();                    
            }
            catch (Exception ex)
            {

                return BadRequest(new { mensagem = "Deu Erro, Confere os erro ai e Tente Novamente, Tente Novamente... " + ex.Message });
                throw;
            }
        }
    }
}