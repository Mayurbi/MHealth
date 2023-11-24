using GlobalSolution.Areas.Identity.Data;
using GlobalSolution.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GlobalSolution.Areas.Identity.Data;

public class MySQLContext : IdentityDbContext<Usuario>
{
    public MySQLContext(DbContextOptions<MySQLContext> options)
        : base(options)
    { }

    public DbSet<Usuario>? Usuarios { get; set; }
    public DbSet<Pedido>? Pedidos { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

    }
 //   protected override void OnModelCreating(ModelBuilder modelBuilder)
//    {
  //      modelBuilder.Entity<UsuarioController>()
   //         .Property(p => p.Classe)
  //          .HasConversion<string>();
  //  }
    public DbSet<GlobalSolution.Models.Paciente> Paciente { get; set; } = default!;
}