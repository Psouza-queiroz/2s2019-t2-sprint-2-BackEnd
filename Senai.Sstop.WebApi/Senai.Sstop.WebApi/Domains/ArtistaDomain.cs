﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Domains
{
    public class ArtistaDomain
    {
        public int IdArtistas { get; set; }
        public string Nome { get; set; }
        public int EstiloId { get; set; }
        public EstiloDomain Estilo { get; set; }
    }
}
