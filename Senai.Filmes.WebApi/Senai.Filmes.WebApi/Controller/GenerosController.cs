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
    [ApiController]
    public class GenerosController : ControllerBase
    {
        GeneroRepository GeneroRepository = new GeneroRepository();

        [HttpGet]
        
        public IEnumerable<GenerosDomain> Listar()
        {
            return GeneroRepository.Listar();
        }

    }
}