using AktifBankCaseStudy.Application.Orders.Commands.CreateOrder;
using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate.Specifications;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate.Specifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Commands.CreateOrderItem;

public class CreateOrderItemCommandHandler : IRequestHandler<CreateOrderItemCommand, IResponseWrapper<bool>>
{
    private readonly IOrderItemRepository _orderItemRepository;
    private readonly IOrderRepository _orderRepository;
    private readonly IProductRepository _productRepository;
    private readonly ILogger<CreateOrderItemCommand> _logger;

    public CreateOrderItemCommandHandler(
        ILogger<CreateOrderItemCommand> logger,
        IOrderItemRepository orderItemRepository,
        IOrderRepository orderRepository,
        IProductRepository productRepository)
    {
        _logger = logger;
        _orderItemRepository = orderItemRepository;
        _orderRepository = orderRepository;
        _productRepository = productRepository;
    }

    public async Task<IResponseWrapper<bool>> Handle(CreateOrderItemCommand request,
        CancellationToken cancellationToken)
    {
        OrderSpecification orderSpec = new OrderSpecification(request.OrderId);
        Order order = await _orderRepository.GetBySpecAsync(orderSpec);
        ProductSpecification productSpecification = new ProductSpecification(request.ProductId);
        Product productEntity = await _productRepository.GetBySpecAsync(productSpecification);
        if (productEntity == null)
        {
            _logger.LogError($"Product with id {request.ProductId} not found.");
            throw new NotFoundException("Product not found.");
        }

        OrderItem orderItem = new OrderItem(Guid.NewGuid(), order.Id, productEntity.Id, productEntity.Price, request.Quantity);

        await _orderItemRepository.AddAsync(orderItem);
        await _orderItemRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
        return new ResponseWrapper<bool>(true);
    }
}