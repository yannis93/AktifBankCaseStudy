using AktifBankCaseStudy.Application.Orders.Commands.CreateOrder;
using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Products.Queries.GetProduct;

public class GetProductQuery:IRequest<IResponseWrapper<GetProducts.ProductDto>>
{
    public GetProductQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }
}