using Microsoft.EntityFrameworkCore;

namespace AuditLoggerPoc
{
    public class AuditTrailDbContext : DbContext
    {
        public DbSet<AuditTrailData> AuditTrailData { get; set; }

        public AuditTrailDbContext(DbContextOptions<AuditTrailDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure the AuditTrailData entity
            modelBuilder.Entity<AuditTrailData>()
                .ToTable("AuditTrail.AuditTrailData")
                .HasKey(a => a.TrailId);
        }
    }

}
