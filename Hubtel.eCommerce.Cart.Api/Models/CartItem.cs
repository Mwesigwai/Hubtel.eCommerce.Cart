using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hubtel.eCommerce.Cart.Api.Models
{
    [Table("CartItem")]
    public class CartItem : ICartItem
    {
        [Key]
        public int ItemId { get; set; }
        [Required,MinLength(10),MaxLength(10)]
        public string PhoneNumber { get; set; }
        [Required,MinLength(3)]
        public string ItemName { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public int UnitPrice { get; set; }
    }
}
