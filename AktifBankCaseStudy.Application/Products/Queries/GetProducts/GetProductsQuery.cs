using AktifBankCaseStudy.Application.Customers.Queries.GetCustomer;
using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Products.Queries.GetProducts;

public class GetProductsQuery:IRequest<IResponseWrapper<List<ProductDto>>>
{
}