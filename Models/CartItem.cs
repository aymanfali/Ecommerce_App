using System.ComponentModel.DataAnnotations;

namespace Ecommerce_App.Models
{
    public class CartItem
    {
        [Required]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}
