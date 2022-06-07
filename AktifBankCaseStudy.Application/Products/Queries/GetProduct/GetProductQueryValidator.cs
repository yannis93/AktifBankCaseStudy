using AktifBankCaseStudy.Application.SeedWork.Validations;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Products.Queries.GetProduct;

public class GetProductQueryValidator : AbstractValidator<GetProductQuery>
{
    public GetProductQueryValidator(ILogger<GetProductQueryValidator> logger)
    {
        RuleFor(query => query.Id).SetValidator(new GuidValidator<GetProductQuery, Guid>()).WithMessage("Invalid UUID");

        logger.LogInformation("----- {ClassName} validation rules assigned", GetType().Name);
    }
}