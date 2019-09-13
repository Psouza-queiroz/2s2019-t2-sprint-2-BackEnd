using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interface;
using Senai.AutoPecas.WebApi.Repositories;
using Senai.AutoPecas.WebApi.ViewModels;

namespace Senai.AutoPecas.WebApi.Controller
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepository { get; set; }

        public UsuariosController()
        {
            UsuarioRepository = new UsuarioRepository();
        }
        [Route("login")]
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuarios usuarioBuscado = UsuarioRepository.Login(login);
                if (usuarioBuscado == null)
                    return NotFound(new { mensagem = "Email ou Senha Inválidos." });

                // informacoes referentes ao usuarios
                var claims = new[]
               {
                        new Claim("chave", "0123456789"),
                        new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                        new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                        new Claim(ClaimTypes.Role, usuarioBuscado.Permissao),
                    };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("AutoPecas-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "AutoPecas.WebApi",
                    audience: "AutoPecas.WebApi",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(30),
                    signingCredentials: creds);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Erro ao cadastrar." + ex.Message });
            }
        }
        [Authorize(Roles = "Fornecedor")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepository.Listar());
        }
       [HttpPost]
        public IActionResult Cadastrar(Usuarios usuarios)
        {
            UsuarioRepository.Cadastrar(usuarios);
            return Ok();
        }
        [Authorize(Roles = "Fornecedor")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UsuarioRepository.Deletar(id);
            return Ok();
        }
    }
} 