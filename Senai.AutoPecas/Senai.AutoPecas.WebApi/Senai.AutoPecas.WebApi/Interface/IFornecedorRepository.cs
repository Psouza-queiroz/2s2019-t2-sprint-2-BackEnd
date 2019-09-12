using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interface
{
    public interface IFornecedorRepository
    {
        List<Fornecedores> Listar(); // httpget        
        void Cadastrar(Fornecedores fornecedores); // htttp post[
        void deletar(int id);

    }
}
