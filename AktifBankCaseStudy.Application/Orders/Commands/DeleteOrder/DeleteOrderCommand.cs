using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Orders.Commands.DeleteOrder
{
    public class DeleteOrderCommand : IRequest<IResponseWrapper<bool>>
    {
        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; init; }
    }
}
