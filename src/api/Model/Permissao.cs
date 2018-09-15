using System.Collections.Generic;

namespace Model
{
    public class Permissao: BaseDataModel
    {
        public Permissao()
        {
        }

        public int Nivel { get; set; }
        public string Nome { get; set; }

        public ICollection<UsuarioPermissao> UsuarioPermissoes { get; set; }
    }
}