using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        public void Cadastrar(Fornecedores fornecedores)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Fornecedores.Add(fornecedores);
                ctx.SaveChanges();
            }       
        }

        public void deletar(int id)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Fornecedores fornecedores = ctx.Fornecedores.Find(id);
                ctx.Remove(fornecedores);
                ctx.SaveChanges();

            }
        }

        public List<Fornecedores> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                 return ctx.Fornecedores.ToList();
            }

        }
    }
}
