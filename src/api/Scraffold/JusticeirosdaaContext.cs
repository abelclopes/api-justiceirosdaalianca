using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Linq;
using System.Threading.Tasks;
using Model;
using Interfaces;

namespace Scraffold
{
    public partial class JusticeirosdaaContext : DbContext, IContext
    {
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Contatos> Contatos { get; set; }
        public DbSet<Spec> Spec { get; set; }
        public DbSet<Posts> Posts { get; set; }
        public DbSet<Character> Character { get; set; }
        public JusticeirosdaaContext()
        {
        }

        public JusticeirosdaaContext(DbContextOptions<JusticeirosdaaContext> options)
            : base(options)
        {
        }

        // public virtual DbSet<Categorias> Categorias { get; set; }
        // public virtual DbSet<Character> Character { get; set; }
        // public virtual DbSet<Contatos> Contatos { get; set; }
        // public virtual DbSet<Posts> Posts { get; set; }
        // public virtual DbSet<Spec> Spec { get; set; }
        // public virtual DbSet<Usuarios> Usuarios { get; set; }

        // Unable to generate entity type for table 'ci_sessions'. Please see the warning messages.

        //         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //         {
        //             if (!optionsBuilder.IsConfigured)
        //             {
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
        //                 optionsBuilder.UseMySql("Server=mysql.justiceirosdaalianca.com.br;Database=justiceirosdaa;User=justiceirosdaa;Password=n1d2x8;");
        //             }
        //         }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.ToTable("categorias");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Categoria)
                    .HasColumnName("categoria")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.Pai)
                    .HasColumnName("pai")
                    .HasColumnType("varchar(80)");

                entity.Property(e => e.Slugcat)
                    .HasColumnName("slugcat")
                    .HasColumnType("varchar(80)");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.ToTable("character");

                entity.HasIndex(e => e.Name)
                    .HasName("name");

                entity.HasIndex(e => e.Spec)
                    .HasName("FK_character_spec");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.AchievementPoints)
                    .HasColumnName("achievementPoints")
                    .HasColumnType("int(20)");

                entity.Property(e => e.Battlegroup)
                    .HasColumnName("battlegroup")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Class)
                    .HasColumnName("class")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Gender)
                    .HasColumnName("gender")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Guild)
                    .HasColumnName("guild")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.GuildRealm)
                    .HasColumnName("guildRealm")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.LastModified)
                    .HasColumnName("lastModified")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Level)
                    .HasColumnName("level")
                    .HasColumnType("int(4)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Race)
                    .HasColumnName("race")
                    .HasColumnType("int(1)");

                entity.Property(e => e.Rank)
                    .HasColumnName("rank")
                    .HasColumnType("varchar(1)");

                entity.Property(e => e.Realm)
                    .HasColumnName("realm")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Spec)
                    .HasColumnName("spec")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Thumbnail)
                    .HasColumnName("thumbnail")
                    .HasColumnType("varchar(255)");
            });

            modelBuilder.Entity<Contatos>(entity =>
            {
                entity.ToTable("contatos");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Char)
                    .HasColumnName("char")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.CiSession)
                    .HasColumnName("ci_session")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Mensagem)
                    .HasColumnName("mensagem")
                    .HasColumnType("text");

                entity.Property(e => e.Nome)
                    .HasColumnName("nome")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Telefone)
                    .HasColumnName("telefone")
                    .HasColumnType("varchar(30)");

                entity.Property(e => e.TipoContato)
                    .HasColumnName("tipoContato")
                    .HasColumnType("int(1)")
                    .HasDefaultValueSql("'0'");
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.ToTable("posts");

                entity.HasIndex(e => e.Categoria)
                    .HasName("categoria");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BreveDescricao)
                    .IsRequired()
                    .HasColumnName("breveDescricao")
                    .HasColumnType("text");

                entity.Property(e => e.Categoria).HasColumnName("categoria");

                entity.Property(e => e.DataCreate)
                    .HasColumnName("dataCreate")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasColumnName("descricao")
                    .HasColumnType("text");

                entity.Property(e => e.Files)
                    .IsRequired()
                    .HasColumnName("files")
                    .HasColumnType("text");

                entity.Property(e => e.Slug)
                    .HasColumnName("slug")
                    .HasColumnType("varchar(150)");

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasColumnName("titulo")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.UsuarioCreate)
                    .HasColumnName("usuario_create")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.Categoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK1_posts_categoria");
            });

            modelBuilder.Entity<Spec>(entity =>
            {
                entity.ToTable("spec");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.BackgroundImage)
                    .HasColumnName("backgroundImage")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasColumnType("text");

                entity.Property(e => e.Icon)
                    .HasColumnName("icon")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasColumnType("varchar(100)");

                entity.Property(e => e.Order)
                    .HasColumnName("order")
                    .HasColumnType("varchar(50)");

                entity.Property(e => e.Role)
                    .HasColumnName("role")
                    .HasColumnType("varchar(5)");
            });

            modelBuilder.Entity<Usuarios>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);

                entity.ToTable("usuarios");

                entity.Property(e => e.UsuarioId)
                    .HasColumnName("usuario_id")
                    .HasColumnType("int(25)");

                entity.Property(e => e.DataCadastro)
                    .HasColumnName("data_cadastro")
                    .HasColumnType("timestamp")
                    .HasDefaultValueSql("'CURRENT_TIMESTAMP'");

                entity.Property(e => e.DataUltimoLogin)
                    .HasColumnName("data_ultimo_login")
                    .HasColumnType("timestamp");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasColumnType("varchar(150)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Info)
                    .IsRequired()
                    .HasColumnName("info")
                    .HasColumnType("text");

                entity.Property(e => e.Ip)
                    .HasColumnName("ip")
                    .HasColumnType("varchar(75)");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasColumnType("varchar(25)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasColumnType("varchar(255)");

                entity.Property(e => e.Sobrenome)
                    .IsRequired()
                    .HasColumnName("sobrenome")
                    .HasColumnType("varchar(25)")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasColumnName("usuario")
                    .HasColumnType("varchar(25)")
                    .HasDefaultValueSql("''");
            });
        }
        public async Task<int> SaveChangesAsync()
        {
            CheckUpdatedEntities();

            return await base.SaveChangesAsync();
        }

        public override int SaveChanges()
        {
            CheckUpdatedEntities();

            return base.SaveChanges();
        }


        private void CheckUpdatedEntities()
        {
            var updatedEntities = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            if (updatedEntities.Any())
            {
                var now = DateTime.UtcNow;

                updatedEntities.Select(x => x.Entity as EntidadeBase).ToList().ForEach(x => x.DataAtualizacao = now);
            }
        }

    }
}
