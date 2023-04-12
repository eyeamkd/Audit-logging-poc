﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AuditLoggerPoc
{
    public class UserDatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

       // public DbSet<AuditTrailData> AuditTrails { get; set; }

        public string DbPath { get; }

        private readonly AuditTrailMediator mediator;

        public UserDatabaseContext(AuditTrailMediator auditTrailMediator)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData; 
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "users.db");
            Console.WriteLine("DB path is " + DbPath);
            mediator = auditTrailMediator;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlite($"Data Source={DbPath}");

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
             
            mediator.OnSaveChangesAsync(this);
/*
            var addedOrUpdatedEntities = ChangeTracker.Entries<User>()
                .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entity in addedOrUpdatedEntities)
            {
                if (entity != null)
                {

                    if (entity.State == EntityState.Added)
                    {
                        AuditTrailData auditTrailData = new AuditTrailData
                        {
                            TrailId = Guid.NewGuid(),
                            Timestamp = DateTime.UtcNow,
                            UserId = entity.Property(x => x.Id).CurrentValue,
                            oldValues = JsonConvert.SerializeObject(entity.OriginalValues.ToObject()),
                            newValues = JsonConvert.SerializeObject(entity.CurrentValues.ToObject()),
                            affectedColumns = "NA",
                            primaryKey = Guid.NewGuid().ToString(),
                            type = "CREATE"
                        };

                        _logger.Log(auditTrailData);
                    }
                    else if (entity.State == EntityState.Modified)
                    {
                        AuditTrailData auditTrailData = new AuditTrailData
                        {
                            TrailId = Guid.NewGuid(),
                            Timestamp = DateTime.UtcNow,
                            UserId = entity.Property(x => x.Id).CurrentValue,
                            oldValues = (string)entity.OriginalValues.ToObject(),
                            newValues = (string)entity.CurrentValues.ToObject(),
                            affectedColumns = "NA",
                            primaryKey = Guid.NewGuid().ToString(),
                            type = "UPDATE"
                        };
                        _logger.Log(auditTrailData);
                    }
                }

            }*/

            return base.SaveChangesAsync(cancellationToken);
        }



    }
}
