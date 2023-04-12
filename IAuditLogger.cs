namespace AuditLoggerPoc
{
    public enum ActivityType
    {
        CREATE , READ, UPDATE, DELETE
    }
    public interface IAuditLogger
    {

        void Log(AuditTrail auditTrailData);
    }
}
