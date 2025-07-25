using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.CommentDtos;
using MultiShop.WebUI.Languages;
using MultiShop.WebUI.Services.CommentServices;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class ProductListController : Controller
    {
        private readonly ICommentService _commentService;
        readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly RequestLocalizationOptions _requestLocalizationOptions;

        public ProductListController(ICommentService commentService, IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _commentService = commentService;
            _stringLocalizer = stringLocalizer;
            _requestLocalizationOptions = requestLocalizationOptions.Value;
        }

        public IActionResult Index(string id)
        {
            var products = _stringLocalizer["inPage.Products"];
            var productList = _stringLocalizer["inPage.ProductList"];

            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = products;
            ViewBag.directory3 = productList;
            
            ViewBag.i = id;
            return View();
        }

        public IActionResult ProductDetail(string id)
        {
            var products = _stringLocalizer["inPage.Products"];
            var productDetails = _stringLocalizer["inPage.ProductDetails"];

            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = products;
            ViewBag.directory3 = productDetails;
            ViewBag.x = id;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.ImageUrl = "test";
            createCommentDto.CreatedDate = DateTime.Parse(DateTime.UtcNow.ToString());
            createCommentDto.Status = false;
            createCommentDto.Rating = 1;
            await _commentService.CreateCommentAsync(createCommentDto);
            return RedirectToAction("ProductDetail", "ProductList", new { id = createCommentDto.ProductID });
        }
    }
}
