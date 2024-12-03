using Store.Models;

namespace Store.Repository
{
    public class SellerInfoRepository : ISellerInfoRepository
    {
        public List<Product> GetProductBySellerId(int id)
        {
            return TempDb.Products.FindAll(x => x.SellerId == id).ToList();
        }

        public Seller? GetSellerById(int id)
        {
            return TempDb.Sellers.SingleOrDefault(x => x.Id == id);
        }

        public List<Seller> GetSellers()
        {
            return TempDb.Sellers;
        }
    }
}
