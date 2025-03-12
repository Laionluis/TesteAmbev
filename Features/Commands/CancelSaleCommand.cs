using MediatR;

namespace TesteAmbev.Features.Commands
{
    public record CancelSaleCommand(Guid SaleId) : IRequest<Unit>;
}
