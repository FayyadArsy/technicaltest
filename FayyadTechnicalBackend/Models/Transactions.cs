using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FayyadTechnicalBackend.Models
{
    public class Transactions
    {
        [Key]
        public int? ID { get; set; }
        public string? Items { get; set; }
        public DateTime? Created_At  { get; set; }
        public DateTime? Updated_At { get; set; }

        [JsonIgnore]
        public Employees? Employees { get; set; }
        [ForeignKey("Employees")]
        public int? EmployeeId { get; set; }
       
    }
}
