using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interface
{
     public interface IUsuarioRepository
    {
        Usuarios Login(LoginViewModel login);
        void Cadastrar(Usuarios usuario);
        List<Usuarios> Listar();
        void Deletar(int id);
    }
}
