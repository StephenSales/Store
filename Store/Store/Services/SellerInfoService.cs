using Store.DTO;
using Store.Models;
using Store.Repository;

namespace Store.Services
{
    public class SellerInfoService : ISellerInfoService
    {
        public readonly ISellerInfoRepository _sellerInfoRepository;

        public SellerInfoService(ISellerInfoRepository sellerInfoRepository)
        {
            _sellerInfoRepository = sellerInfoRepository;
        }

        public SellerDTO? GetSellerById(int id)
        {
            var seller = _sellerInfoRepository.GetSellerById(id);

            if (seller == null)
            {
                return null;
            }

            return new SellerDTO()
            {
                Name = seller.Name,
                products = _sellerInfoRepository.GetProductBySellerId(seller.Id),
            };
        }

        public List<SellerDTO> GetSellers()
        {
            List<SellerDTO> result = new List<SellerDTO>();

            var sellers = _sellerInfoRepository.GetSellers();

            foreach (Seller seller in sellers)
            {
                result.Add(new SellerDTO()
                {
                    Name = seller.Name,
                    products = _sellerInfoRepository.GetProductBySellerId(seller.Id),
                });
            }

            return result;
        }
    }
}
