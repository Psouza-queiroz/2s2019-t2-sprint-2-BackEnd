﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.Repositories;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")] 
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        ArtistaRepository ArtistaRepository = new ArtistaRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(ArtistaRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(ArtistaDomain artista)
        {
            ArtistaRepository.Cadastrar(artista);
            return Ok();
        }
    }
}