using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;

namespace AuditLoggerPoc
{
    public class AuditTrailMediator
    {
        private readonly IAuditLogger _logger;

        public AuditTrailMediator(IAuditLogger logger)
        {
            _logger = logger;
        }

        public void OnSaveChangesAsync(UserDatabaseContext context)
        {
            var addedOrUpdatedEntities = context.ChangeTracker.Entries<User>()
             .Where(x => x.State == EntityState.Added || x.State == EntityState.Modified);

            foreach (var entity in addedOrUpdatedEntities)
            {
                if (entity != null)
                {

                    if (entity.State == EntityState.Added)
                    {
                        AuditTrail auditTrailData = new AuditTrail
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
                        var modifiedProperties = entity.Properties
                                                   .Where(p => p.IsModified)
                                                   .Select(p => p.Metadata.Name)
                                                   .ToList();
                        AuditTrail auditTrailData = new AuditTrail
                        {
                            TrailId = Guid.NewGuid(),
                            Timestamp = DateTime.UtcNow,
                            UserId = entity.Property(x => x.Id).CurrentValue,
                            oldValues = JsonConvert.SerializeObject(entity.OriginalValues.ToObject()),
                            newValues = JsonConvert.SerializeObject(entity.CurrentValues.ToObject()),
                            affectedColumns = JsonConvert.SerializeObject(modifiedProperties),
                            primaryKey = Guid.NewGuid().ToString(),
                            type = "UPDATE"
                        };
                        _logger.Log(auditTrailData);
                    }
                }

            }
        }

        private AuditTrail CreateAuditTrailData(EntityEntry entityEntry)
        {
            // Create an audit trail log for the entity
            var auditTrailData = new AuditTrail
            {
                // Set the audit trail data properties
            };

            return auditTrailData;
        }
    }

}
