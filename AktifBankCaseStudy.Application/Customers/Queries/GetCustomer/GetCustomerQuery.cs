using AktifBankCaseStudy.Application.Customers.Queries.GetCustomer;
using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Products.Queries.GetProduct;

public class GetCustomerQuery:IRequest<IResponseWrapper<CustomerDto>>
{
    public GetCustomerQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }
}