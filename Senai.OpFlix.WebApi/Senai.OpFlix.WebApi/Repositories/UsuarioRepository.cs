using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interface;
using Senai.OpFlix.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios Login(LoginViewModel Login)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == Login.Email && x.Senha == Login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }

        public void Cadastar(Usuarios usuarios)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();
            }
        }
        public List<Usuarios> Listar()
        {


            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public void Deletar(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Usuarios usuarios = ctx.Usuarios.Find(id);

                ctx.Remove(usuarios);

                ctx.SaveChanges();
            }




        }
    }
}

