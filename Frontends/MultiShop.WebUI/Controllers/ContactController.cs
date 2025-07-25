using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using MultiShop.DtoLayer.CatalogDtos.ContactDtos;
using MultiShop.WebUI.Languages;
using MultiShop.WebUI.Services.CatalogServices.ContactServices;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;
        readonly IStringLocalizer<Lang> _stringLocalizer;
        private readonly RequestLocalizationOptions _requestLocalizationOptions;

        public ContactController(IContactService contactService, IStringLocalizer<Lang> stringLocalizer, IOptions<RequestLocalizationOptions> requestLocalizationOptions)
        {
            _contactService = contactService;
            _stringLocalizer = stringLocalizer;
            _requestLocalizationOptions = requestLocalizationOptions.Value;
        }

        public IActionResult Index()
        {
            var contact = _stringLocalizer["inPage.Contact"];
            var sendMessage = _stringLocalizer["inPage.SendMessage"];

            ViewBag.directory1 = "MultiShop";
            ViewBag.directory2 = contact;
            ViewBag.directory3 = sendMessage;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            createContactDto.IsRead = false;
            createContactDto.SendDate = DateTime.Parse(DateTime.UtcNow.ToString());
            await _contactService.CreateContactAsync(createContactDto);
            return RedirectToAction("Index");
        }
    }
}
