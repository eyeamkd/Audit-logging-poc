namespace AuditLoggerPoc.Attributes
{
    public class AuditableAttribute : Attribute
    { 
        public bool IsAuditable { get; }

        public AuditableAttribute(bool isAuditable) 
        {
            IsAuditable = isAuditable;
        }
    }
}
