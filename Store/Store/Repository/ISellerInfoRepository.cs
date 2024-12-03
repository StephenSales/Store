using Store.Models;

namespace Store.Repository
{
    public interface ISellerInfoRepository
    {
        public List<Seller> GetSellers();
        public Seller? GetSellerById(int id);
        public List<Product> GetProductBySellerId(int id);
    }
}
