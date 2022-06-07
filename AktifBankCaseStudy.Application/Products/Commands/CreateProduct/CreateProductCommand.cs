using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Products.Commands.CreateProduct;

public class CreateProductCommand: IRequest<IResponseWrapper<bool>>
{
    public string Name { get; init; }
    public string Barcode { get; init; }
    public string Description { get; init; }
    public int Quantity { get; init; }
    public decimal Price { get; init; }
}