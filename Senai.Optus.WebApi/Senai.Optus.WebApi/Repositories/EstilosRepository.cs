using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstilosRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }
        public void cadastrar (Estilos estilos)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Estilos.Add(estilos);
                    ctx.SaveChanges();
            }
        }
        public void atualizar (Estilos estilos)
        {

        }
             
    }
}
