using Microsoft.EntityFrameworkCore;
using PawCare.Models;

namespace PawCare.Data
{
    public class PawCareContext : DbContext
    {
        public PawCareContext(DbContextOptions<PawCareContext> options)
            : base(options)
        {
        }

        public DbSet<Mascota> Mascotas { get; set; }
    }
}