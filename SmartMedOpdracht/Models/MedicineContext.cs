using Microsoft.EntityFrameworkCore;

namespace SmartMedOpdracht.Models
{
    public class MedicineContext : DbContext
    {
        public MedicineContext(DbContextOptions<MedicineContext> options) : base(options)
        {}
        public DbSet<Medicine> Medicine { get; set; }
    }
}