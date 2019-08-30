using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class CargoRepository
    {
        public void Cadastrar(Cargos cargos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Cargos.Add(cargos);
                ctx.SaveChanges();
            }
        }
        public List<Cargos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.ToList();
            }   
        }
        public Cargos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Cargos.FirstOrDefault(x => x.IdCargo == id);
            }
        }
        public void Atualizar ( Cargos cargos)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Cargos AtualizarCargo = ctx.Cargos.FirstOrDefault(x => x.IdCargo == cargos.IdCargo);
                AtualizarCargo.Nome = cargos.Nome;
                ctx.Cargos.Update(AtualizarCargo);
                ctx.SaveChanges();
            }
        }
        public void Deletar (int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {

            }
        }
    }
}
