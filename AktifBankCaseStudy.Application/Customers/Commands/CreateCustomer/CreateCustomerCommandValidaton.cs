using AktifBankCaseStudy.Application.Products.Commands.CreateProduct;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommandValidaton: AbstractValidator<CreateCustomerCommand>
{
    public CreateCustomerCommandValidaton(ILogger<CreateCustomerCommand> logger)
    {
        RuleFor(query=>query.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(query=>query.Address.Country).NotEmpty().WithMessage("Country is required");
        RuleFor(query=>query.Address.City).NotEmpty().WithMessage("City is required");
        RuleFor(query=>query.Address.Street).NotEmpty().WithMessage("Street is required");
        RuleFor(query=>query.Address.ZipCode).NotEmpty().WithMessage("ZipCode is required");
        RuleFor(query=>query.Address.Description).NotEmpty().WithMessage("Description is required");
        logger.LogInformation("----- {ClassName} validation rules assigned", GetType().Name);
    }
}