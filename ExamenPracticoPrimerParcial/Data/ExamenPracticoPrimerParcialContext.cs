using Microsoft.EntityFrameworkCore;

namespace ExamenPracticoPrimerParcial.Data
{
    public class ExamenPracticoPrimerParcialContext : DbContext
    {
        public ExamenPracticoPrimerParcialContext (DbContextOptions<ExamenPracticoPrimerParcialContext> options)
            : base(options)
        {
        }

        public DbSet<ExamenPracticoPrimerParcial.Models.Candidato> Candidato { get; set; } = default!;
    }
}
