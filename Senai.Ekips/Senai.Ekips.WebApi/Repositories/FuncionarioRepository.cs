using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionarioRepository
    {
        public void Cadastrar (Funcionarios funcionarios)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Add(funcionarios);
                ctx.SaveChanges();
            }
        }
        
        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.ToList();
            }
        }
        public Funcionarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            }
        }
        public void Atualizar(Funcionarios funcionarios)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios AtualizarFuncionario = ctx.Funcionarios.FirstOrDefault(x =>
                x.IdFuncionario == funcionarios.IdFuncionario);
                if(funcionarios.Nome != null)
                {
                AtualizarFuncionario.Nome = funcionarios.Nome;
                }
                ctx.Funcionarios.Update(AtualizarFuncionario);
                ctx.SaveChanges();
            }
        }
        public void Deletar (int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Funcionarios funcionarios = ctx.Funcionarios.Find(id);
                ctx.Remove(funcionarios);
                ctx.SaveChanges();
            }
        }
    }
}
