using Microsoft.EntityFrameworkCore;
using Examen.Model;

namespace Examen.Context
{
    public class Cuenta_Context : DbContext
    {
        public DbSet<Cuenta> cuentas { get; set; }
        public DbSet<Tarjeta> tarjetas { get; set; }
        public DbSet<Usuario> usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseMySQL("server=localhost; database=cuentas;user=root; password=1234");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Cuenta>(entiy =>
            {
                entiy.HasKey(c => c.Num_Cuenta);
                entiy.Property(c => c.Titular);
                entiy.Property(c => c.Tipo_cuenta);
                entiy.Property(c => c.Saldo);
                entiy.Property(c => c.Movimiento);
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(t => t.Num_Tarjeta);
                entity.Property(t => t.Titular);
                entity.Property(t => t.Saldo);
                entity.Property(t => t.Fecha_vencimiento);
                entity.Property(t => t.CVV);
            });

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