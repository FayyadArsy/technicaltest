using System.ComponentModel.DataAnnotations;

namespace FayyadTechnicalBackend.Models
{
    public class Items
    {
        [Key]
        public int? Id { get; set; }
        public string? Name { get; set; }
        public int? Quantity { get; set; }
        public decimal? Price { get; set; }
    }
}
