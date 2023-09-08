using Ecommerce_App.Models;
using System.ComponentModel.DataAnnotations;

namespace Ecommerce_App.ViewModels
{
    public class ProductCategoryViewModel
    {
        [Required]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal? ProductPrice { get; set; }
        public int CategoryId { get; set; }
        public List<Category> Categories { get; set; }

        public IFormFile File { get; set; }
        public string ImageUrl { get; set; }
    }
}
