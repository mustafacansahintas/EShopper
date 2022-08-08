using EShopper.Entities;
using System.ComponentModel.DataAnnotations;

namespace EShopper.WEBUI.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(60,MinimumLength =5,ErrorMessage ="Ürün ismi minimum 5 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required]
        public string ImageUrl { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 10, ErrorMessage = "Ürün açıklaması minimum 10 karakter olmalıdır.")]
        public string Description { get; set; }
        [Required(ErrorMessage ="Fiyat Belirtiniz")]
        [Range(3000,30000)]
        public decimal? Price { get; set; }
        public List<Category> SelectedCategories { get; set; }

        public ProductModel()
        {
            SelectedCategories = new List<Category>();
        }
    }
}
