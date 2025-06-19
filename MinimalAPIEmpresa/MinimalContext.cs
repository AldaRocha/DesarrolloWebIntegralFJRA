using Microsoft.EntityFrameworkCore;
using MinimalAPIEmpresa.Models;

namespace MinimalAPIEmpresa
{
    public class MinimalContext : DbContext
    {
        public MinimalContext(DbContextOptions<MinimalContext> options) : base(options)
        {
        }

        public DbSet<Ciudad> Ciudad { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<EmpleadoDepartamento> EmpleadoDepartamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasKey(p => new { p.EmpleadoId, p.DepartamentoId });

            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasOne(p => p.Empleado)
                .WithMany(p => p.EmpleadoDepartamentos)
                .HasForeignKey(p => p.EmpleadoId);

            modelBuilder.Entity<EmpleadoDepartamento>()
                .HasOne(p => p.Departamento)
                .WithMany(p => p.EmpleadoDepartamentos)
                .HasForeignKey(p => p.DepartamentoId);

            modelBuilder.Entity<Ciudad>().HasData(
                new Ciudad
                {
                    CiudadId = 1,
                    Nombre = "CDMX"
                },
                new Ciudad
                {
                    CiudadId = 2,
                    Nombre = "Guadalajara"
                },
                new Ciudad
                {
                    CiudadId = 3,
                    Nombre = "Monterrey"
                }
            );
        }
    }
}
