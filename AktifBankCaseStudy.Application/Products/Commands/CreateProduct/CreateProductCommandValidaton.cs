using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidaton: AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidaton(ILogger<CreateProductCommandValidaton> logger)
    {
        RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(command => command.Barcode).NotEmpty().WithMessage("Barcode is required");
        RuleFor(command => command.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(command => command.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(command => command.Quantity).NotEmpty().WithMessage("Quantity is required");
            
        logger.LogInformation("----- {ClassName} validation rules assigned", GetType().Name);
    }
}