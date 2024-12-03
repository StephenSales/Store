using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        [ForeignKey(nameof(Product.Id))]
        public int SellerId { get; set; }
    }
}
