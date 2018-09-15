using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Model;

namespace Interfaces
{
    public interface IContext
    {
        DbSet<Usuario> Usuarios { get; set; }
        DbSet<Permissao> Permissoes { get; set; }
        DbSet<UsuarioPermissao> UsuarioPermissoes { get; set; }
        DbSet<Posts> Propostas { get; set; }
        DbSet<PostsAnexo> PropostaAnexos { get; set; }
        DbSet<Categoria> Categorias { get; set; }        
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}