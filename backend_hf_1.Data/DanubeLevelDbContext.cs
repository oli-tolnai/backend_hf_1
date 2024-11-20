using backend_hf_1.Entities.Entity_Models;
using Microsoft.EntityFrameworkCore;

namespace backend_hf_1.Data
{
    public class DanubeLevelDbContext : DbContext
    {
        public DbSet<DanubeLevel> DanubeLevels { get; set; }

        //Constructor
        public DanubeLevelDbContext(DbContextOptions<DanubeLevelDbContext> ctx)
            :base(ctx)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DanubeLevel>();

            /*
            modelBuilder.Entity<DanubeLevel>(entity =>
            {
                entity.HasKey(e => e.Id); // Elsődleges kulcs

                entity.Property(e => e.Date)
                    .IsRequired() // Nem lehet null
                    .HasColumnType("date"); // Csak a dátumot tárolja

                entity.Property(e => e.Value)
                    .IsRequired() // Nem lehet null
                    .HasColumnType("int"); // Egész számként tárolja a vízállási értéket
            });
            */

            base.OnModelCreating(modelBuilder);
        }

    }
}
