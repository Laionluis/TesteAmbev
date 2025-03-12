using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TesteAmbev.Data;
using TesteAmbev.DTOs;
using TesteAmbev.Features.Querys;

namespace TesteAmbev.Features.Handlers
{
    public class GetSaleHandler : IRequestHandler<GetSaleQuery, SaleDTO>
    {
        private readonly SalesDbContext _context;
        private readonly IMapper _mapper;

        public GetSaleHandler(SalesDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SaleDTO> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            var sale = await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == request.SaleId);
            return sale == null ? null : _mapper.Map<SaleDTO>(sale);
        }
    }
}
