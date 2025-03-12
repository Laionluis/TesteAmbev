using MediatR;
using TesteAmbev.DTOs;

namespace TesteAmbev.Features.Querys
{
    public record GetSaleQuery(Guid SaleId) : IRequest<SaleDTO>;
}
