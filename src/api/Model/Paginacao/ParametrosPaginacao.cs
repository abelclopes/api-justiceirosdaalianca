using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class ParametrosPaginacao{
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string buscaTermo { get; set; }
    }
    public class PaginationParamsPosts{
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string CategoriaID { get; set; } 
 
    }

}