using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class ProductDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public int SellerId { get; set; }
    }
}
