using Microsoft.EntityFrameworkCore;
using SimpleGameApi.Models.Domain.Entities;

namespace SimpleGameApi.Models.Infrastructure.Data.Contexts;

public class JogoDbContext : DbContext
{
    public JogoDbContext(DbContextOptions<JogoDbContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.EnableSensitiveDataLogging();
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<Jogo> Jogos { get; set; }  
    public DbSet<Estoque> Estoque { get; set; }
}
