using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }
        public List<Usuarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Usuarios.ToList();
            }

        }
        public void Deletar(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Usuarios usuarios = ctx.Usuarios.Find(id);
                ctx.Remove(usuarios);
                ctx.SaveChanges();
            }
        }
       
    }
}
