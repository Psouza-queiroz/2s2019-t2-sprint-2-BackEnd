using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class DepartamentoRepository
    {
        public void Cadastrar(Departamentos Departamento)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Departamentos.Add(Departamento);
                ctx.SaveChanges();
            }
        }
        public List<Departamentos> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.ToList();
            }
        }
        public Departamentos BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Departamentos.FirstOrDefault(x => x.IdDepartamento == id);
            }
        }
    }
}
