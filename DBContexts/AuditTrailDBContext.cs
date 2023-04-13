using AuditLoggerPoc.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AuditLoggerPoc.DBContexts
{
    public class AuditTrailDbContext : DbContext
    {
        public DbSet<AuditTrail> AuditTrailData { get; set; }
        public string DbPath { get; }


        public AuditTrailDbContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "users.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    }

}
