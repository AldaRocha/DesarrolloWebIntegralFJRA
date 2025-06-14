using Ejemplo_EntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace Ejemplo_EntityFramework
{
    public class TareasContext : DbContext
    {
        public TareasContext(DbContextOptions<TareasContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tarea> Tareas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            List<Categoria> categoriasInit = new List<Categoria>();
            categoriasInit.Add(new Categoria
            {
                CategoriaId = Guid.Parse("dee61528-3227-436a-b19a-280e06686c85"),
                Nombre = "Actividades Pendientes",
                Descripcion = "Actividades de Trabajo y/o escuela",
                Peso = 20
            });
            categoriasInit.Add(new Categoria
            {
                CategoriaId = Guid.Parse("dee61528-3227-436a-b19a-280e06686c02"),
                Nombre = "Actividades Personales",
                Descripcion = "Actividades de Carácter Personal",
                Peso = 50
            });

            modelBuilder.Entity<Categoria>(categoria =>
            {
                categoria.ToTable("Categorias");
                categoria.HasKey(p => p.CategoriaId);
                categoria.Property(p => p.Nombre).IsRequired().HasMaxLength(150);
                categoria.Property(p => p.Descripcion).IsRequired(false);
                categoria.Property(p => p.Peso);

                categoria.HasData(categoriasInit);
            });

            List<Tarea> TareasInit = new List<Tarea>();
            TareasInit.Add(new Tarea
            {
                TareaId = Guid.Parse("a50f2609-7f0c-46cc-8352-d2b40065a9f0"),
                CategoriaId = Guid.Parse("dee61528-3227-436a-b19a-280e06686c85"),
                PrioridadTarea = Prioridad.Media,
                Titulo = "Pago de servicios",
                Descripcion = "Pagar servicios de Agua y Luz",
                FechaCreacion = new DateTime(2025, 06, 11, 20, 19, 00)
            });
            TareasInit.Add(new Tarea
            {
                TareaId = Guid.Parse("a50f2609-7f0c-46cc-8352-d2b40065a910"),
                CategoriaId = Guid.Parse("dee61528-3227-436a-b19a-280e06686c02"),
                PrioridadTarea = Prioridad.Baja,
                Titulo = "Terminar de ver Película Eso",
                Descripcion = "Terminar de ver en Neflix",
                FechaCreacion = new DateTime(2025, 06, 11, 20, 25, 00)
            });

            modelBuilder.Entity<Tarea>(tarea =>
            {
                tarea.ToTable("Tareas");
                tarea.HasKey(p => p.TareaId);
                tarea.HasOne(p => p.Categoria).WithMany(p => p.Tareas).HasForeignKey(p => p.CategoriaId);
                tarea.Property(p => p.Titulo).IsRequired().HasMaxLength(200);
                tarea.Property(p => p.Descripcion).IsRequired(false);
                tarea.Property(p => p.PrioridadTarea);
                tarea.Property(p => p.FechaCreacion);
                tarea.Ignore(p => p.Resumen);

                tarea.HasData(TareasInit);
            });
        }
    }
}
