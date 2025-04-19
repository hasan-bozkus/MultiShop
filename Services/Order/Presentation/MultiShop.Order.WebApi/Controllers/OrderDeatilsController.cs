using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDeatilsController : ControllerBase
    {
        private readonly GetOrderDeatilByIdQueryHandler _getOrderDeatilByIdQueryHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly GetOrderDeatilQueryHandler _getOrderDetailQueryHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDeatilsController(GetOrderDeatilByIdQueryHandler getOrderDeatilByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, GetOrderDeatilQueryHandler getOrderDetailQueryHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getOrderDeatilByIdQueryHandler = getOrderDeatilByIdQueryHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> OrderDeatilList()
        {
            var values = await _getOrderDetailQueryHandler.Handle();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderDeatil(int id)
        {
            var values = await _getOrderDeatilByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrderDeatil(CreateOrderDetailCommand command)
        {
            await _createOrderDetailCommandHandler.Handle(command);
            return Ok("Ekleme işlemi başarılı");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrderDeatil(UpdateOrderDetailCommand command)
        {
            await _updateOrderDetailCommandHandler.Handle(command);
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrderDetail(int id)
        {
            await _removeOrderDetailCommandHandler.Handle(new RemoveOrderDetailCommand(id));
            return Ok("Silme işlemi başarılı");
        }
    }
}
