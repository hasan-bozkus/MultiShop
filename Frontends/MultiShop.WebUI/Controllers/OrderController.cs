using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.OrderDtos.OrderAddressDtos;
using MultiShop.WebUI.Languages;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderAddressService _orderAddressService;
        private readonly IUserService _userService;
        readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly RequestLocalizationOptions _requestLocalizationOptions;

        public OrderController(IOrderAddressService orderAddressService, IUserService userService, IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _stringLocalizer = stringLocalizer;
            _requestLocalizationOptions = requestLocalizationOptions.Value;
            _orderAddressService = orderAddressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var orders = _stringLocalizer["inPage.Orders"];
            var orderTransactions = _stringLocalizer["inPage.OrderTransactions"];

            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = orders;
            ViewBag.directory3 = orderTransactions;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateOrderAddressDto createOrderAddressDto)
        {
            var values = await _userService.GetUserInfo();
            createOrderAddressDto.UserId = values.Id;
            createOrderAddressDto.Description = "aaaaa";
            await _orderAddressService.CreateOrderAddressAsync(createOrderAddressDto);
            return RedirectToAction("Index", "Payment");
        }
    }
}
