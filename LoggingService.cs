namespace AuditLoggerPoc
{
    public class LoggingService : IAuditLogger
    {
        private readonly AuditTrailDbContext _auditTrailDbContext;
        public LoggingService(AuditTrailDbContext auditTrailDbContext) 
        {
            _auditTrailDbContext = auditTrailDbContext;
        }

        public void Log(AuditTrailData auditTrailData)
        {
            _auditTrailDbContext.AuditTrailData.Add(auditTrailData);

        }
    }
}
