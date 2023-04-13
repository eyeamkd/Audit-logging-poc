using AuditLoggerPoc.DBContexts;
using AuditLoggerPoc.Models.DataModels;

namespace AuditLoggerPoc
{
    public class LoggingService : IAuditLogger
    {
        private readonly AuditTrailDbContext _auditTrailDbContext;
        //private readonly UserDatabaseContext _userDatabaseContext;
        public LoggingService(AuditTrailDbContext auditTrailDbContext) 
        {
            _auditTrailDbContext = auditTrailDbContext;
           // _userDatabaseContext = userDatabaseContext;
        }

        public void Log(AuditTrail auditTrailData)
        {
            _auditTrailDbContext.AuditTrailData.Add(auditTrailData);
        }

        public void SaveLog()
        {
            _auditTrailDbContext.SaveChanges();
        }
    }
}
