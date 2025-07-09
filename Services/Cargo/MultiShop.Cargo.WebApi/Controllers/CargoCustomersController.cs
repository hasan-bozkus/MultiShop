using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = _cargoCustomerService.TGetList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var values = _cargoCustomerService.TGetById(id);
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto createCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                Name = createCargoCustomerDto.Name,
                Surname = createCargoCustomerDto.Surname,
                Email = createCargoCustomerDto.Email,
                Phone = createCargoCustomerDto.Phone,
                City = createCargoCustomerDto.City,
                Disctrict = createCargoCustomerDto.Disctrict,
                Address = createCargoCustomerDto.Address,
                UserCustomerId = createCargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _cargoCustomerService.TDelete(id);
            return Ok("Silme işlemi başarılı");
        }

        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto updateCargoCustomerDto)
        {
            CargoCustomer cargoCustomer = new CargoCustomer()
            {
                CargoCustomerId = updateCargoCustomerDto.CargoCustomerId,
                Name = updateCargoCustomerDto.Name,
                Surname = updateCargoCustomerDto.Surname,
                Email = updateCargoCustomerDto.Email,
                Phone = updateCargoCustomerDto.Phone,
                City = updateCargoCustomerDto.City,
                Disctrict = updateCargoCustomerDto.Disctrict,
                Address = updateCargoCustomerDto.Address,
                UserCustomerId = updateCargoCustomerDto.UserCustomerId
            };
            _cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetCargoCustomerById/{id}")]
        public async Task<IActionResult> GetCargoCustomerById(string id)
        {
            var values = await _cargoCustomerService.TGetCargoCustomerById(id);
            return Ok(values);
        }
    }
}
