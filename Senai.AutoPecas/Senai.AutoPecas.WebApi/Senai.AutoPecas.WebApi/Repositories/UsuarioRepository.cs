using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interface;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public void Cadastrar(Usuarios usuarios)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();
            }
        }

        public List<Usuarios> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public Usuarios Login(LoginViewModel login)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {

                Usuarios usuarios = ctx.Usuarios.Find(id);

            ctx.Remove(usuarios);

            ctx.SaveChanges();
            }
        }
    }
}
