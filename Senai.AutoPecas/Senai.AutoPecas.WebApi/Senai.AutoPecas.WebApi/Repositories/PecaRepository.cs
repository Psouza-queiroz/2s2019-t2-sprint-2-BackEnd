using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class PecaRepository : IPecasRepository
    {
        public void Atualizar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Pecas AtualizarPecas = ctx.Pecas.FirstOrDefault(x => x.IdPeca == pecas.IdPeca);
                AtualizarPecas.Descricao = pecas.Descricao;
                AtualizarPecas.Peso = pecas.Peso;
                AtualizarPecas.PrecoDeCusto = pecas.PrecoDeCusto;
                AtualizarPecas.CodigoDaPeca = pecas.CodigoDaPeca;

                ctx.Pecas.Update(AtualizarPecas);
              ctx.SaveChanges();  
            }
        }

        public Pecas BuscarPorId(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.FirstOrDefault(x => x.IdPeca == id);
            }
        }

        public void Cadastrar(Pecas pecas)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Pecas.Add(pecas);
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {

                Pecas pecas = ctx.Pecas.Find(id);
            ctx.Remove(pecas);
            ctx.SaveChanges();
            }
        }

        public List<Pecas> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Pecas.ToList();
            }
        }
    }
}
