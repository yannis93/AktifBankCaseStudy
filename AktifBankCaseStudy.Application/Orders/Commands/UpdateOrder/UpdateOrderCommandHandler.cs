using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate.Specifications;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, IResponseWrapper<bool>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<UpdateOrderCommand> _logger;

        public UpdateOrderCommandHandler(
            ILogger<UpdateOrderCommand> logger,
            IOrderRepository orderRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task<IResponseWrapper<bool>> Handle(UpdateOrderCommand request,
            CancellationToken cancellationToken)
        {
            OrderSpecification orderSpecification = new OrderSpecification(request.Id);
            Order order = await _orderRepository.GetBySpecAsync(orderSpecification);
            if (order == null) 
                throw new NotFoundException("Order not found");

            order.UpdateOrder(request.Address.City, request.Address.Street, request.Address.ZipCode, request.Address.Country, request.Address.Description);

            await _orderRepository.UpdateAsync(order);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            return new ResponseWrapper<bool>(true);
        }
    }
}