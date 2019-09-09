using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriaRepository CategoriaRepository = new CategoriaRepository();
        [Authorize]
        [HttpGet]
      
        public IActionResult Listar()
        {
            return Ok(CategoriaRepository.Listar());
        }

        [HttpPost]

        public IActionResult Cadastrar(Categorias categoria)
        {
                try
                {
                    CategoriaRepository.Cadastrar(categoria);
                    return Ok();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { mensagem = "eita, erro: " + ex.Message });
                }
        }
        [Authorize(Roles = "Administrador")]
        [HttpGet("{id}")]
        
        public IActionResult BuscarPorId(int id)
        {
            Categorias categorias = CategoriaRepository.BuscarPorId(id);
            if (categorias == null)
                return NotFound(); ;
            return Ok(categorias);            
        }
       [HttpPut]
       public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                Categorias CategoriaBuscada = CategoriaRepository.BuscarPorId
                    (categoria.IdCategoria);

                if (CategoriaBuscada == null)
                    return NotFound();

                CategoriaRepository.Atualizar(categoria);
                return Ok();
           
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "ah, não." + ex.Message });
                throw;
            }
            
        }
           

            [HttpDelete("{id}")]
            public IActionResult Deletar (int id)
            {
                CategoriaRepository.Deletar(id);
                return Ok();
            }
    }
    
}