using Store.DTO;

namespace Store.Services
{
    public interface ISellerInfoService
    {
        List<SellerDTO> GetSellers();
        SellerDTO? GetSellerById(int id);
    }
}
