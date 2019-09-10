using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformaRepository : IPlataformaRepository
    {

        public void Cadastrar(Plataforma plataforma)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Plataforma.Add(plataforma);
                ctx.SaveChanges();
            }
        }
   

        public List<Plataforma> Listar()
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Plataforma.ToList();
            }
        }
     

        public Plataforma BuscarPorId(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }

      
        public void atualizar(Plataforma plataforma)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Plataforma AtualizarPlataforma = ctx.Plataforma.FirstOrDefault(x => x.IdPlataforma == plataforma.IdPlataforma);
                AtualizarPlataforma.Nome = plataforma.Nome;
                ctx.Plataforma.Update(AtualizarPlataforma);
                ctx.SaveChanges();

            }
        }
    }
}
