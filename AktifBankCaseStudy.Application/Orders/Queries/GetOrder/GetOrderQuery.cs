using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Orders.Queries.GetOrder;

public class GetOrderQuery:IRequest<IResponseWrapper<OrderDto>>
{
    public GetOrderQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; init; }
}