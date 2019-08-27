using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Usuarios Usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (Usuario == null)
                    return null;
                return Usuario;

                

               
            }
        }


        public void Cadastrar(Usuarios Usuarios)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Usuarios.Add(Usuarios);
                ctx.SaveChanges();
            }
        }

       
   
       


    }
}
