using Microsoft.AspNetCore.Mvc;
using Store.DTO;
using Store.Models;
using Store.Services;

namespace Store.Controllers
{
    [ApiController]
    [Route("api/sellers")]
    public class SellersController : ControllerBase
    {
        private readonly ISellerInfoService _sellerInfoService;

        public SellersController(ISellerInfoService sellerInfoService)
        {
            _sellerInfoService = sellerInfoService;
        }

        [HttpGet]
        public IActionResult GetSellers()
        {
            var sellers = _sellerInfoService.GetSellers();

            return Ok(sellers);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult GetSellerById(int id)
        {
            var seller = _sellerInfoService.GetSellerById(id);

            if (seller == null)
            {
                return NotFound($"Seller with id {id} not found.");
            }

            return Ok(seller);
        }
    }
}
