using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Product : BaseEntity {
        [KeyAttribute]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public int Quantity { get; set; }
        public string Image { get; set; }
    }
}