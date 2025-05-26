using Microsoft.EntityFrameworkCore;

namespace MvcMovie_IDGS902.Data
{
    public class MvcMovie_IDGS902Context : DbContext
    {
        public MvcMovie_IDGS902Context (DbContextOptions<MvcMovie_IDGS902Context> options)
            : base(options)
        {
        }

        public DbSet<MvcMovie_IDGS902.Models.Movie> Movie { get; set; } = default!;
    }
}
