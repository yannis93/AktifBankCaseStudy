using AktifBankCaseStudy.Application.Products.Commands.CreateProduct;
using AktifBankCaseStudy.Application.Products.Queries.GetProduct;
using AktifBankCaseStudy.Application.SeedWork.Validations;
using FluentValidation;
using Microsoft.Extensions.Logging;

namespace AktifBankCaseStudy.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandValidaton: AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidaton(ILogger<UpdateProductCommandValidaton> logger)
    {
        RuleFor(command => command.Id).SetValidator(new GuidValidator<UpdateProductCommand, Guid>()).WithMessage("Invalid UUID");
        RuleFor(command => command.Name).NotEmpty().WithMessage("Name is required");
        RuleFor(command => command.Barcode).NotEmpty().WithMessage("Barcode is required");
        RuleFor(command => command.Description).NotEmpty().WithMessage("Description is required");
        RuleFor(command => command.Price).NotEmpty().WithMessage("Price is required");
        RuleFor(command => command.Quantity).NotEmpty().WithMessage("Quantity is required");
            
        logger.LogInformation("----- {ClassName} validation rules assigned", GetType().Name);
    }
}