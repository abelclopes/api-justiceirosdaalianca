using System;
using System.Collections.Generic;

namespace Scraffold
{
    public partial class Categorias
    {
        public Categorias()
        {
            Posts = new HashSet<Posts>();
        }

        public ulong Id { get; set; }
        public string Categoria { get; set; }
        public string Slugcat { get; set; }
        public string Pai { get; set; }

        public ICollection<Posts> Posts { get; set; }
    }
}
