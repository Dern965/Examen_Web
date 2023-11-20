using Examen.Model;
using Microsoft.EntityFrameworkCore;
using MySql.EntityFrameworkCore;

namespace Examen.Context
{
    public class BancoContext : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Cuenta> Cuenta { get; set; }
        public DbSet<Tarjeta> Tarjeta { get; set; }
        public DbSet<Movimiento> Movimiento { get; set; }

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
            modelBuilder.Entity<Cuenta>(entity => {
                entity.HasKey(c => c.Num_Cuenta);
                entity.Property(c => c.Saldo);
                entity.Property(c => c.Tipo_cuenta);
                entity.Property(c => c.Movimientos);
                entity.Property(c => c.Titular);
            });
            modelBuilder.Entity<Tarjeta>(entity => {
                entity.HasKey(t => t.Num_Tarjeta);
                entity.Property(t => t.Saldo);
                entity.Property(t => t.Fecha_vencimiento);
                entity.Property(t => t.CVV);
                entity.Property(t => t.Titular);
            });
            modelBuilder.Entity<Movimiento>(entity => {
                entity.HasKey(m => m.Num_Movimiento);
                entity.Property(m => m.Num_Cuenta);
                entity.Property(m => m.Num_Tarjeta);
                entity.Property(m => m.Usuario1);
                entity.Property(m => m.Usuario2);
                entity.Property(m => m.Tipo_Movimiento);
                entity.Property(m => m.Descripcion);
                entity.Property(m => m.Cantidad);
                entity.Property(m => m.Fecha);
                entity.Property(m => m.Hora);
                entity.Property(m => m.Num_Cuenta2);
                entity.Property(m => m.Num_Tarjeta2);
            });
        }
    }
}
