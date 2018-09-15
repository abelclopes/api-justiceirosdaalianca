using System;

namespace Model
{
    public class PostsModel
    {
        public long Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string BreveDescricao { get; set; }
        public string Files { get; set; }
        public DateTime DataCreate { get; set; }
        public ulong Categoria { get; set; }
        public int? Status { get; set; }
        public int? UsuarioCreate { get; set; }
        public string Slug { get; set; }

    }
}