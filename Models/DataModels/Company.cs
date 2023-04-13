using AuditLoggerPoc.Attributes;
using System.ComponentModel.DataAnnotations;

namespace AuditLoggerPoc.Models.DataModels
{
    [Auditable(true)]
    public class Company
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int Strength { get; set; }

        public string LineOfBusiness { get; set; }


    }
}
