using AktifBankCaseStudy.Application.Orders.Commands.UpdateOrder;
using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate.Specifications;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, IResponseWrapper<bool>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ILogger<UpdateOrderCommand> _logger;

        public DeleteOrderCommandHandler(
            ILogger<UpdateOrderCommand> logger,
            IOrderRepository orderRepository,
            IProductRepository productRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
        }

        public async Task<IResponseWrapper<bool>> Handle(DeleteOrderCommand request,
            CancellationToken cancellationToken)
        {
            OrderSpecification orderSpecification = new OrderSpecification(request.Id);
            Order order = await _orderRepository.GetBySpecAsync(orderSpecification);
            if (order == null)
                throw new NotFoundException("Order not found");

            order.Delete();
            
            await _orderRepository.UpdateAsync(order);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            return new ResponseWrapper<bool>(true);
        }
    }
}