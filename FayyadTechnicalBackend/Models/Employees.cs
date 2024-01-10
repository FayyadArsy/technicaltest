using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FayyadTechnicalBackend.Models
{
    public class Employees
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? phone { get; set; }
        
    }
}
