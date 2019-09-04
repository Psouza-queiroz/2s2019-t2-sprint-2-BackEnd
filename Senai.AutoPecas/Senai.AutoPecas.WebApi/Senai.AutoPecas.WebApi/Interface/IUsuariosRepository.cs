using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interface
{
     public interface IUsuariosRepository
    {
        Usuarios Login(LoginViewModel login);
    }
}
