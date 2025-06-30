using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace EmpleadosApi.Models
{
    public partial class BdEmpleados903Context : DbContext // Mark the class as partial  
    {
        public BdEmpleados903Context()
        {
        }

        public BdEmpleados903Context(DbContextOptions<BdEmpleados903Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Empleado> Empleados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Nombre).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Correo).IsRequired().HasMaxLength(100);
                entity.Property(e => e.tel).IsRequired().HasMaxLength(15);
                entity.Property(e => e.FechaNacimiento).IsRequired();
                entity.Property(e => e.sexo).IsRequired().HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder); // Ensure the partial method is called  
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder); // Partial method declaration  
    }
}