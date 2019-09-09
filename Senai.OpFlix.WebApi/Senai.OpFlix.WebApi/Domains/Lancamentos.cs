using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Lancamentos
    {
        public int IdLancamento { get; set; }
        public string Nome { get; set; }
        public string Sinopse { get; set; }
        public int DuracaoMin { get; set; }
        public DateTime DataDeLancamento { get; set; }
        public int? IdPlataforma { get; set; }
        public int? IdCategoria { get; set; }
        public int? IdTipo { get; set; }
        public int? IdClassificacao { get; set; }

        public Categorias IdCategoriaNavigation { get; set; }
        public Classificacao IdClassificacaoNavigation { get; set; }
        public Plataforma IdPlataformaNavigation { get; set; }
        public Tipos IdTipoNavigation { get; set; }
    }
}
