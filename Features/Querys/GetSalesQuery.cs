using MediatR;
using TesteAmbev.DTOs;

namespace TesteAmbev.Features.Querys
{
    public record GetSalesQuery(int Page, int PageSize) : IRequest<List<SaleDTO>>;
}
