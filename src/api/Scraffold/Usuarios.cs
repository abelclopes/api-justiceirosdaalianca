using System;
using System.Collections.Generic;

namespace Scraffold
{
    public partial class Usuarios
    {
        public int UsuarioId { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public string Usuario { get; set; }
        public string Senha { get; set; }
        public string Info { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataUltimoLogin { get; set; }
        public string Ip { get; set; }
    }
}
