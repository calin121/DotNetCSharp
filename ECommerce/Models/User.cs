using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class User : BaseEntity {
        [KeyAttribute]
        public int UserId { get; set; }
        public string Name { get; set; }

    }
}