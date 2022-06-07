using AktifBankCaseStudy.Application.SeedWork.Exceptions;
using AktifBankCaseStudy.Application.SeedWork.Models;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.CustomerAggregate.Specifications;
using AktifBankCaseStudy.Domain.AggregatesModel.OrderAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate;
using AktifBankCaseStudy.Domain.AggregatesModel.ProductAggregate.Specifications;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, IResponseWrapper<Guid>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<CreateOrderCommand> _logger;

        public CreateOrderCommandHandler(
            ILogger<CreateOrderCommand> logger,
            IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository)
        {
            _logger = logger;
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        public async Task<IResponseWrapper<Guid>> Handle(CreateOrderCommand request,
            CancellationToken cancellationToken)
        {
            CustomerSpecification customerSpecification = new CustomerSpecification(request.CustomerId);
            var customer = await _customerRepository.GetBySpecAsync(customerSpecification);
            if (customer == null) 
                throw new NotFoundException("Customer not found");
            
            var orderId = Guid.NewGuid();
            Order order = new Order(Guid.NewGuid(), customer.Id,
                new Address(request.Address.Street, request.Address.City,
                    request.Address.Country, request.Address.ZipCode, request.Address.Description));
            foreach (var requestProduct in request.Products)
            {
                ProductSpecification productSpecification = new ProductSpecification(requestProduct.Id);
                Product productEntity = await _productRepository.GetBySpecAsync(productSpecification);
                if (productEntity == null)
                {
                    _logger.LogError($"Product with id {requestProduct.Id} not found.");
                    throw new NotFoundException($"Product with id {requestProduct.Id} not found.");
                }
                order.AddOrderItem(Guid.NewGuid(), requestProduct.Id, productEntity.Price, requestProduct.Quantity);
            }

            await _orderRepository.AddAsync(order);
            await _orderRepository.UnitOfWork.SaveEntitiesAsync();
            return new ResponseWrapper<Guid>(orderId);
        }
    }
}