using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class UsuarioRepository
    {
        public List<Usuarios> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Usuarios.ToList();
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

        public Usuarios BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Usuarios.FirstOrDefault(x => x.IdUsuario == id);
            }
        }
        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                Usuarios Usuario = ctx.Usuarios.Find(id);

                ctx.Remove(Usuario);

                ctx.SaveChanges();
            }
        }


    }
}
