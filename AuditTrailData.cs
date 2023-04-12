using System.ComponentModel.DataAnnotations;

namespace AuditLoggerPoc
{
    public class AuditTrailData
    {
        [Key]
        public Guid TrailId { get; set; }

        public Guid UserId { get; set;  }

        public string type { get; set; }

        public DateTime Timestamp { get; set; }

        public string oldValues { get; set; }

        public string newValues { get; set; }    

        public string affectedColumns { get; set; }   

        public string primaryKey { get; set; } 

    }
}
