using System;
using System.Collections.Generic;

namespace Scraffold
{
    public partial class Contatos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Status { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Char { get; set; }
        public string Mensagem { get; set; }
        public string CiSession { get; set; }
        public int? TipoContato { get; set; }
    }
}
