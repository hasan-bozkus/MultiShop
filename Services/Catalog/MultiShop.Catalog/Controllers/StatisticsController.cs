using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Services.StatisticServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IStatisticService _statisticService;

        public StatisticsController(IStatisticService statisticService)
        {
            _statisticService = statisticService;
        }

        [HttpGet("GetProductCount")]
        public async Task<IActionResult> GetProductCount()
        {
            var count = await _statisticService.GetProductCount();
            return Ok(count);
        }

        [HttpGet("GetCategoryCount")]
        public async Task<IActionResult> GetCategoryCount()
        {
            var count = await _statisticService.GetCategoryCount();
            return Ok(count);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _statisticService.GetBrandCount();
            return Ok(values);
        }
        
        [HttpGet("GetProductAvgPrice")]
        public async Task<IActionResult> GetProductAvgPrice()
        {
            var avgPrice = await _statisticService.GetProductAvgPrice();
            return Ok(avgPrice);
        }
        
        [HttpGet("GetMaxPriceProductName")]
        public async Task<IActionResult> GetMaxPriceProductName()
        {
            var avgPrice = await _statisticService.GetMaxPriceProductName();
            return Ok(avgPrice);
        }
        
        [HttpGet("GetMinPriceProductName")]
        public async Task<IActionResult> GetMinPriceProductName()
        {
            var avgPrice = await _statisticService.GetMinPriceProductName();
            return Ok(avgPrice);
        }
    }
}
