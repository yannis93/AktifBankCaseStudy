using AktifBankCaseStudy.Application.Orders.Commands.CreateOrderItem;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate.Specifications;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate.Specifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Commands.DeleteOrderItem;

public class DeleteOrderItemCommandHandler : IRequestHandler<DeleteOrderItemCommand, IResponseWrapper<bool>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ILogger<DeleteOrderItemCommand> _logger;

    public DeleteOrderItemCommandHandler(
        ILogger<DeleteOrderItemCommand> logger,
        IOrderRepository orderRepository,
        IProductRepository productRepository)
    {
        _logger = logger;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<IResponseWrapper<bool>> Handle(DeleteOrderItemCommand request,
        CancellationToken cancellationToken)
    {
        OrderSpecification orderSpec = new OrderSpecification(request.OrderId);
        Order order = await _orderRepository.GetBySpecAsync(orderSpec);

        order.RemoveOrderItem(request.OrderItemId);

        await _orderRepository.UpdateAsync(order);
        await _orderRepository.UnitOfWork.SaveEntitiesAsync();
        return new ResponseWrapper<bool>(true);
    }
}