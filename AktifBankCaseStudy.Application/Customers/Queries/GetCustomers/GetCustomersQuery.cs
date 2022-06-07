using AktifBankCaseStudy.Application.Customers.Queries.GetCustomer;
using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Customers.Queries.GetCustomers;

public class GetCustomersQuery:IRequest<IResponseWrapper<IEnumerable<CustomerDto>>>
{
}