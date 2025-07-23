using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.CatalogDtos.CategoryDtos;
using MultiShop.WebUI.Languages;
using MultiShop.WebUI.Services.CatalogServices.CategoryServices;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text.Json.Nodes;

namespace MultiShop.WebUI.ViewComponents.UILayoutViewComponents
{
    public class _NavbarUILayoutComponentPartial : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly RequestLocalizationOptions _requestLocalizationOptions;

        public _NavbarUILayoutComponentPartial(ICategoryService categoryService, IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _categoryService = categoryService;
            _stringLocalizer = stringLocalizer;
            _requestLocalizationOptions = requestLocalizationOptions.Value;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ViewBag.InPageHomePage = _stringLocalizer["inPage.HomePage"];
            ViewBag.InPageProducts = _stringLocalizer["inPage.Products"];
            ViewBag.InPageProductDeatils = _stringLocalizer["inPage.ProductDeatils"];
            ViewBag.InPageDealOftheDay = _stringLocalizer["inPage.DealoftheDay"];
            ViewBag.InPagePages = _stringLocalizer["inPage.Pages"];
            ViewBag.InPageMyCart = _stringLocalizer["inPage.MyCart"];
            ViewBag.InPagePayment = _stringLocalizer["inPage.Payment"];
            ViewBag.InPageSignUp = _stringLocalizer["inPage.SignUp"];
            ViewBag.InPageSignIn = _stringLocalizer["inPage.SignIn"];
            ViewBag.InPageCategories = _stringLocalizer["inPage.Categories"];
            ViewBag.InPageContact = _stringLocalizer["inPage.Contact"];
            ViewBag.inPageCustomerService = _stringLocalizer["inPage.CustomerService"];

            var values = await _categoryService.GetAllCategoryAsync();
            return View(values);
        }
    }
}
