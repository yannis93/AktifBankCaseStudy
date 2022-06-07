using AktifBankCaseStudy.Application.Products.Queries.GetProduct;
using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate.Specifications;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate.Specifications;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Queries.GetOrder;

public class GetOrderQueryHandler: IRequestHandler<GetOrderQuery, IResponseWrapper<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ILogger<GetOrderQueryHandler> _logger;
    private readonly IMapper _mapper;

    public GetOrderQueryHandler(
        IMapper mapper,
        ILogger<GetOrderQueryHandler> logger,
        IOrderRepository orderRepository)
    {
        _mapper = mapper;
        _logger = logger;
        _orderRepository = orderRepository;
    }

    public async Task<IResponseWrapper<OrderDto>> Handle(GetOrderQuery request,
        CancellationToken cancellationToken)
    {
        OrderSpecification spec = new OrderSpecification(request.Id);
        Order order = await _orderRepository.GetBySpecAsync(spec, cancellationToken);

        if (order == null)
            throw new NotFoundException("Order not found");

        return new ResponseWrapper<OrderDto>(_mapper.Map<Order, OrderDto>(order));
    }
}