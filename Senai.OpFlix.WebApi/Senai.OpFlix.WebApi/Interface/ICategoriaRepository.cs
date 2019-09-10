using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interface
{
    public interface ICategoriaRepository
    {
        List<Categorias> Listar();
        void Cadastrar(Categorias categoria);
        void Atualizar(Categorias categorias);
        Categorias BuscarPorId(int id);

    }
}
