using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.BasketDto;
using MultiShop.WebUI.Languages;
using MultiShop.WebUI.Services.BasketServices;
using MultiShop.WebUI.Services.CatalogServices.ProductServices;

namespace MultiShop.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IProductService _productService;
        private readonly IBasketService _basketService;
        readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly RequestLocalizationOptions _requestLocalizationOptions;

        public ShoppingCartController(IProductService productService, IBasketService basketService, IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _productService = productService;
            _basketService = basketService;
            _stringLocalizer = stringLocalizer;
            _requestLocalizationOptions = requestLocalizationOptions.Value;
        }

        public IActionResult Index(string code, int discountRate, decimal totalNewPriceWithDiscount)
        {
            ViewBag.code = code;
            ViewBag.discountRate = discountRate;
            ViewBag.totalNewPriceWithDiscount = totalNewPriceWithDiscount;
            
            var products = _stringLocalizer["inPage.Products"];
            var myCart = _stringLocalizer["inPage.MyCart"];

            ViewBag.directory1 = "Multi Shop";
            ViewBag.directory2 = products;
            ViewBag.directory3 = myCart;

            return View();
        }

        public async Task<IActionResult> AddBasketItem(string id)
        {
            var values = await _productService.GetByIDProductAsync(id);
            var items = new BasketItemDto
            {
                ProductId = values.ProductID,
                ProductName = values.ProductName,
                Price = values.ProductPrice,
                Quantity = 1,
                ProductImageUrl = values.ProductImageUrl
            };
            await _basketService.AddBasketItem(items);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> RemoveBasketItem(string id)
        {
            await _basketService.RemoveBasketItem(id);
            return RedirectToAction("Index");
        }
    }
}
