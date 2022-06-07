using AktifBankCaseStudy.Application.SeedWork.Validations;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Orders.Commands.DeleteOrder
{
    public class UpdateOrderCommandValidation : AbstractValidator<DeleteOrderCommand>
    {
        public UpdateOrderCommandValidation(ILogger<UpdateOrderCommandValidation> logger)
        {
            RuleFor(command => command.Id).SetValidator(new GuidValidator<DeleteOrderCommand, Guid>()).WithMessage("Invalid UUID");

            logger.LogInformation("----- {ClassName} validation rules assigned", GetType().Name);
        }
    }
}
