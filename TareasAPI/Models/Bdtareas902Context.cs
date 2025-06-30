using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TareasAPI.Models;

public partial class Bdtareas902Context : DbContext
{
    public Bdtareas902Context()
    {
    }

    public Bdtareas902Context(DbContextOptions<Bdtareas902Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Tarea> Tareas { get; set; }
    public virtual DbSet<Empleado> Empleados { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tarea>(entity =>
        {
            entity.HasKey(e => e.TareaId).HasName("PK__Tarea__5CD83991BB4E3736");

            entity.ToTable("Tarea");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
