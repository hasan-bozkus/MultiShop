using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class GetOrderDeatilByIdQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetOrderDeatilByIdQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery query)
        {
            var value = await _repository.GetByIdAsync(query.Id);
            return new GetOrderDetailByIdQueryResult
            {
                OrderDeatilId = value.OrderDeatilId,
                ProductId = value.ProductId,
                ProductName = value.ProductName,
                ProductPrice = value.ProductPrice,
                ProductAmount = value.ProductAmount,
                ProductTotalPrice = value.ProductTotalPrice,
                OrderingId = value.OrderingId
            };
        }
    }
}
