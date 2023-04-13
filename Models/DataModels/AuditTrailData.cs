using AuditLoggerPoc.Attributes;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AuditLoggerPoc.Models.DataModels
{
    [Table("AuditTrails")]
    [Auditable(false)]
    public class AuditTrail
    {
        [Key]
        public Guid TrailId { get; set; }

        public Guid UserId { get; set; }

        public string type { get; set; }

        public DateTime Timestamp { get; set; }

        public string oldValues { get; set; }

        public string newValues { get; set; }

        public string affectedColumns { get; set; }

        public string primaryKey { get; set; }

    }
}
