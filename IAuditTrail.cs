namespace AuditLoggerPoc
{
    public interface IAuditTrail<T>
    {
        public Guid UserId { get; set;  }

        public string type { get; set; }

        public DateTime Timestamp { get; set; }

        public T oldValues { get; set; }

        public T newValues { get; set; }    

        public string[] affectedColumns { get; set; }   

        public object primaryKey { get; set; } 

    }
}
