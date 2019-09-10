using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interface
{
    interface IPlataformaRepository
    {
        List<Plataforma> Listar();
        void Cadastrar(Plataforma plataforma);
        Plataforma BuscarPorId(int id);
        void atualizar(Plataforma plataforma);
    }
}
