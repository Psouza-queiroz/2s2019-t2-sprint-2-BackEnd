﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interface;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedoresController : ControllerBase
    {
        private IFornecedorRepository FornecedorRepository { get; set; }

        public FornecedoresController()
        {
            FornecedorRepository = new FornecedorRepository();
        }
        [HttpPost]
        public IActionResult Cadastrar(Fornecedores fornecedores)
        {
            FornecedorRepository.Cadastrar(fornecedores);
            return Ok();

        }
        
        
        [HttpGet]
        public IActionResult Listar ()
        {
            return Ok(FornecedorRepository.Listar());
        }
        [HttpDelete ("{id}")]
        public IActionResult Deletar (int id)
        {
            FornecedorRepository.deletar(id);
            return Ok(); 
        }
    }
}