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
       
        public void Atualizar(Categorias categorias)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Categorias AtualizarCategorias = ctx.Categorias.FirstOrDefault(x => x.IdCategoria == categorias.IdCategoria);
                AtualizarCategorias.Categoria = categorias.Categoria;
                ctx.Categorias.Update(AtualizarCategorias);
                ctx.SaveChanges();

            }
        }

        public Categorias BuscarPorId(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }





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
