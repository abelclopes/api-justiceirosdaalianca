using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Scraffold;

namespace Interfaces
{
    public interface IContext
    {
        DbSet<Categorias> Categorias { get; set; }  
        DbSet<Usuarios> Usuarios { get; set; }
        DbSet<Contatos> Contatos { get; set; }
        DbSet<Spec> Spec { get; set; }
        DbSet<Posts> Posts { get; set; }
        DbSet<Character> Character { get; set; }      
        DatabaseFacade Database { get; }
        Task<int> SaveChangesAsync();
        int SaveChanges();
    }
}