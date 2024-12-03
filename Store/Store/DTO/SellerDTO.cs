using Store.Models;
using System.ComponentModel.DataAnnotations;

namespace Store.DTO
{
    public class SellerDTO
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        public List<Product> products { get; set; }
    }
}
