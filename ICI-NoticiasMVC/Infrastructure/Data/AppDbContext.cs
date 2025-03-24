using ICI_NoticiasMVC.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace ICI_NoticiasMVC.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Noticia> Noticias => Set<Noticia>();
        public DbSet<Tag> Tags => Set<Tag>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuração da relação muitos-para-muitos entre Noticia e Tag
            modelBuilder.Entity<Noticia>()
                .HasMany(n => n.Tags)
                .WithMany(t => t.Noticias)
                .UsingEntity(j =>
                    j.ToTable("NoticiaTags")); // nome da tabela de junção no banco

            // Relação Noticia → Usuario (muitos para um)
            modelBuilder.Entity<Noticia>()
                .HasOne(n => n.Usuario)
                .WithMany() // Unidirecional: sem navegação reversa
                .HasForeignKey(n => n.UsuarioId)
                .OnDelete(DeleteBehavior.Restrict); // Evita cascade delete

            base.OnModelCreating(modelBuilder);
        }
    }

}
