using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentoRepository : ILancamentoRepository
    {
        public void Atualizar(Lancamentos lancamentos)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Lancamentos AtualizarLancamentos = ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == lancamentos.IdLancamento);
            AtualizarLancamentos.Nome = lancamentos.Nome;
                AtualizarLancamentos.Sinopse = lancamentos.Sinopse;
                AtualizarLancamentos.DuracaoMin = lancamentos.DuracaoMin;
                AtualizarLancamentos.DataDeLancamento = lancamentos.DataDeLancamento;
                AtualizarLancamentos.IdPlataforma = lancamentos.IdPlataforma;
                AtualizarLancamentos.IdCategoria = lancamentos.IdCategoria;
                AtualizarLancamentos.IdTipo = lancamentos.IdTipo;
                AtualizarLancamentos.IdClassificacao = lancamentos.IdClassificacao;

            ctx.Lancamentos.Update(AtualizarLancamentos);
            ctx.SaveChanges();
            }
        }


        public Lancamentos BuscarPorId(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }
        }


        public void Cadastrar(Lancamentos lancamentos)
        {
            using (opflixContext ctx = new opflixContext())
            {
                ctx.Lancamentos.Add(lancamentos);
                ctx.SaveChanges();
            }
        }


        public void Deletar(int id)
        {
            using (opflixContext ctx = new opflixContext())
            {
                Lancamentos lancamentos = ctx.Lancamentos.Find(id);
                ctx.Remove(lancamentos);
                ctx.SaveChanges();
            }
        }


        public List<Lancamentos> Listar()
        {
            using (opflixContext ctx = new opflixContext())
            {
                return ctx.Lancamentos.ToList();

            }
        }
    }
}
