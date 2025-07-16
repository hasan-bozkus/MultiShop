using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CommentServices;
using MultiShop.WebUI.Services.StatisticServices.CatalogStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.DiscountStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.MessageStatisticServices;
using MultiShop.WebUI.Services.StatisticServices.UserStatisticServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StatisticController : Controller
    {
        private readonly ICatalogStatisticService _catalogStatisticService;
        private readonly IUserStatisticService _userStatisticService;
        private readonly ICommentService _commentService;
        private readonly IDiscountStatisticService _discountStatisticService;
        private readonly IMessageStatisticService _messageStatisticService;

        public StatisticController(ICatalogStatisticService catalogStatisticService, IUserStatisticService userStatisticService, ICommentService commentService, IDiscountStatisticService discountStatisticService, IMessageStatisticService messageStatisticService)
        {
            _catalogStatisticService = catalogStatisticService;
            _userStatisticService = userStatisticService;
            _commentService = commentService;
            _discountStatisticService = discountStatisticService;
            _messageStatisticService = messageStatisticService;
        }

        public async Task<IActionResult> Index()
        {
            #region catalog statistics
            var brandCount = await _catalogStatisticService.GetBrandCount();
            ViewBag.brandCount = brandCount;

            var categoryCount = await _catalogStatisticService.GetCategoryCount();
            ViewBag.categoryCount = categoryCount;

            var productCount = await _catalogStatisticService.GetProductCount();
            ViewBag.productCount = productCount;

            //var productAvgPrice = await _catalogStatisticService.GetProductAvgPrice();
            ViewBag.productAvgPrice = "38"; // = productAvgPrice;

            var maxPriceProductName = await _catalogStatisticService.GetMaxPriceProductName();
            ViewBag.maxPriceProductName = maxPriceProductName;

            var minPriceProductName = await _catalogStatisticService.GetMinPriceProductName();
            ViewBag.minPriceProductName = minPriceProductName;
            #endregion

            #region user statistics
            var userCount = await _userStatisticService.GetUserCount();
            ViewBag.userCount = userCount;
            #endregion

            #region comment statistics

            var totalCommentCount = await _commentService.GetTotalCommentCount();
            ViewBag.totalCommentCount = totalCommentCount;

            var activeCommentCount = await _commentService.GetActiveCommentCount();
            ViewBag.activeCommentCount = activeCommentCount;

            var passiveCommentCount = await _commentService.GetPassiveCommentCount();
            ViewBag.passiveCommentCount = passiveCommentCount;

            #endregion

            #region discount statistics

            var discountCouponCount = await _discountStatisticService.GetDiscountCouponCountAsync();
            ViewBag.discountCouponCount = discountCouponCount;

            #endregion

            #region message statistics

            var totalMessageCount = await _messageStatisticService.GetTotalMessageCountAsync();
            ViewBag.totalMessageCount = totalMessageCount;

            #endregion
            return View();
        }
    }
}
