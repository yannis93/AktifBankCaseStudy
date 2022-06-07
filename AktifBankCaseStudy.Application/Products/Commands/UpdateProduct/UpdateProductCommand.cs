using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommand: IRequest<IResponseWrapper<bool>>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Barcode { get; init; }
    public string Description { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}