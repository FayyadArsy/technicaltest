using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FayyadTechnicalBackend.Models
{
    public class Cart
    {
        [Key]
        public int? CartId { get; set; }
        public int? ItemsId { get; set; }
        public int? Quantity { get; set; }
        public int? TransactionId { get; set; }

        
        public Items Items { get; set; }

    }
}
