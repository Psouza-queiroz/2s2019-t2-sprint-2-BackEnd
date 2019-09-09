using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public void Cadastrar(Categorias categoria)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Categorias.Add(categoria);
                ctx.SaveChanges();
            }
        }

        public List<Categorias> Listar()
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Categorias.ToList();
            }
        }
    }
}
