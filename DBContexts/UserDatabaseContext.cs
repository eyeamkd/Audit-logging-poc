using AuditLoggerPoc.Attributes;
using AuditLoggerPoc.Models.DataModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Reflection;
using System.Xml;

namespace AuditLoggerPoc.DBContexts
{
    public class UserDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companies { get; set; }

        public string DbPath { get; }

        private readonly AuditTrailMediator mediator;

        public UserDatabaseContext(AuditTrailMediator auditTrailMediator)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = Path.Join(path, "users.db");
            mediator = auditTrailMediator;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasQueryFilter(e => e.GetType().GetCustomAttribute<AuditableAttribute>()!=null 
            && e.GetType().GetCustomAttribute<AuditableAttribute>().IsAuditable == true);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                mediator.OnSaveChangesAsync(this);
                return base.SaveChangesAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                mediator.SaveLogChanges();
            }   
        }



    }
}
