using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.BasketServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.ViewComponents.ShoppingCartViewComponents
{
    public class _ShoppingCartDiscountCouponComponentPartial : ViewComponent
    {
        private readonly IBasketService _basketService;

        public _ShoppingCartDiscountCouponComponentPartial(IBasketService basketService)
        {
            _basketService = basketService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var values = await _basketService.GetBasket();
            var totalPriceWithTax = values.TotalPrice + values.TotalPrice/100*10;
            var tax = values.TotalPrice / 100 * 10;
            ViewBag.totalPriceWithTax = totalPriceWithTax;
            ViewBag.tax = tax;
            return View(values);
        }
    }
}
