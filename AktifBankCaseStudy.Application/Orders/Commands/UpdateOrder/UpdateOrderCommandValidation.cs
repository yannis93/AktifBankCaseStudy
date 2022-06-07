using AktifBankCaseStudy.Application.SeedWork.Validations;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Commands.UpdateOrder
{
    public class UpdateOrderCommandValidation : AbstractValidator<UpdateOrderCommand>
    {
        public UpdateOrderCommandValidation(ILogger<UpdateOrderCommandValidation> logger)
        {
            RuleFor(command => command.Id).SetValidator(new GuidValidator<UpdateOrderCommand, Guid>()).WithMessage("Invalid UUID");
            RuleFor(command => command.Address).NotEmpty().WithMessage("Address is required");

            logger.LogInformation("----- {ClassName} validation rules assigned", GetType().Name);
        }
    }
}
