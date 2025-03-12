using MediatR;
using TesteAmbev.DTOs;

namespace TesteAmbev.Features.Commands
{
    public record CreateSaleCommand(SaleDTO Sale) : IRequest<SaleDTO>;
}
