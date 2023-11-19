using Examen.Model;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace Examen.Context
{
    public class BancoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL("server=localhost; database=Banco;user=root; password=admin");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Usuario>(entity => {
                entity.HasKey(u => u.NombreUsuario);
                entity.Property(u => u.Nombre);
                entity.Property(u => u.Contrasena);
                entity.Property(u => u.Cuentas);
                entity.Property(u => u.Tarjetas);
            });
        }
    }
}
