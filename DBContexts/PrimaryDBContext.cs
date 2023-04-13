using AuditLoggerPoc.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AuditLoggerPoc.DBContexts
{
    public class PrimaryDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Property> Properties { get; set; }

        public DbSet<AuditTrail> AuditTrails { get; set; }

        public DbSet<Company> Companies { get; set; }

        public string DbPath { get; }

        public PrimaryDBContext() 
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "users.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");

    }
}
