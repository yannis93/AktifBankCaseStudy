using AktifBankCaseStudy.Application.SeedWork.Models;
using MediatR;

namespace AktifBankCaseStudy.Application.Orders.Commands.DeleteOrderItem;

public class DeleteOrderItemCommand: IRequest<IResponseWrapper<bool>>
{
    public DeleteOrderItemCommand(Guid orderItemId, Guid orderId)
    {
        OrderItemId = orderItemId;
        OrderId = orderId;
    }

    public Guid OrderItemId { get; init; }
    public Guid OrderId { get; init; }
}