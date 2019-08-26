using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domain;
using Senai.Filmes.WebApi.Repository;

namespace Senai.Filmes.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]

        public IEnumerable<GenerosDomain> Listar()
        {
            return GeneroRepository.Listar();
        }

        [HttpPost]
        public IActionResult Cadastrar(GenerosDomain generos)
        {
            GeneroRepository.Cadastrar(generos);
            return Ok();
        }
        [HttpGet("{Id}")]

        public IActionResult BuscarPorId(int id)
        {
            GenerosDomain generosDomain = GeneroRepository.BuscarPorId(id);
            if (generosDomain == null)
            
                return NotFound();
                return Ok(generosDomain);
        }

        [HttpPut]
        public IActionResult Atualizar (GenerosDomain generos)
        {
            GeneroRepository.Atualizar(generos);
            return Ok();
        }
        [HttpDelete("{Id}")]
        public IActionResult Deletar(int id)
        {
            GeneroRepository.Deletar(id);
            return Ok();
        }
    }
}
