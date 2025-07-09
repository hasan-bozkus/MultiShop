using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        public async Task<IActionResult> CargoCompanyList()
        {
            var values = await _cargoCompanyService.GetAllCargoCompanyAsync();
            return View(values);
        }

        [HttpGet]
        public IActionResult CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);      
            return RedirectToAction("CargoCompanyList");
        }

        public async Task<IActionResult> DeleteCargoCompany(int  id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);
            return RedirectToAction("CargoCompanyList");
        }

        [HttpGet]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var result = await _cargoCompanyService.GetByIDCargoCompanyAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);      
            return RedirectToAction("CargoCompanyList");
        }

    }
}
