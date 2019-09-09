using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interface
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();
        Usuarios Login(LoginViewModel Login);
        void Deletar(int id);
        void Cadastar(Usuarios usuarios);
    }
}
