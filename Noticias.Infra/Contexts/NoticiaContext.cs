using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Noticias.Domain.Entities;

namespace Noticias.Infra.Contexts;

public class NoticiaContext : DbContext
{
    public NoticiaContext() { }

    public NoticiaContext(DbContextOptions<NoticiaContext> options) : base(options) { }

    public DbSet<Noticia> Noticias { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySql("server=localhost;port=3306;User Id=root;database=Noticias;Pwd=ROOT;", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}