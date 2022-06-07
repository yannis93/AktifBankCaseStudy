using AktifBankCaseStudy.Application.SeedWork.Validations;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Products.Queries.GetProduct;

public class GetCustomerQueryValidator : AbstractValidator<GetCustomerQuery>
{
    public GetCustomerQueryValidator(ILogger<GetCustomerQueryValidator> logger)
    {
        RuleFor(query => query.Id).SetValidator(new GuidValidator<GetCustomerQuery, Guid>()).WithMessage("Invalid UUID");

        logger.LogInformation("----- {ClassName} validation rules assigned", GetType().Name);
    }
}