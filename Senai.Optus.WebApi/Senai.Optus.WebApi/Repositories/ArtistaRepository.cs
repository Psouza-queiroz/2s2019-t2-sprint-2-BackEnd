﻿using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistaRepository
    {
        public List<Artistas> Listar ()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.ToList();
            }
        }
        public void Cadastrar (Artistas artistas)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Artistas.Add(artistas);
                ctx.SaveChanges();
            }

        }
        public Artistas BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.FirstOrDefault(x => x.IdArtista == id);
               
            }
        }
    }
}
