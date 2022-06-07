using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidation(ILogger<CreateOrderCommandValidation> logger)
        {
            RuleFor(command => command.CustomerId).NotEmpty().WithMessage("Customer Id is required");
            RuleFor(command => command.Products).NotNull().WithMessage("Products are required");
            RuleFor(command => command.Address).NotEmpty().WithMessage("Address is required");

            logger.LogInformation("----- {ClassName} validation rules assigned", GetType().Name);
        }
    }
}
