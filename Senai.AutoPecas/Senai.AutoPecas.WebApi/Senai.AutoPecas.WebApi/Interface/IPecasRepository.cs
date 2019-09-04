using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interface
{
     public interface IPecasRepository
    {
        List<Pecas> Listar(); // httpget
        Pecas BuscarPorId(int id); // httpget id
        void Cadastrar(Pecas pecas); // htttp post 
        void Atualizar(Pecas pecas); // http put
        void Deletar(int id); // http delete id
    }
}
