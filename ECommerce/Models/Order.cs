using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models {
    public class Order {
        [KeyAttribute]
        public int OrderId { get; set; }
        public int OrderQuantity { get; set; }
        public User UserID { get; set; }
        public User Users { get; set; }
        public Product ProductId { get; set; }
        public Product Products { get; set; }

    }
}