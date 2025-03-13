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
        private readonly ILogger<GetSaleHandler> _logger;

        public GetSaleHandler(SalesDbContext context, IMapper mapper, ILogger<GetSaleHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SaleDTO> Handle(GetSaleQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching sale with ID: {SaleId}", request.SaleId);
            var sale = await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == request.SaleId);
            if (sale == null)
            {
                _logger.LogWarning("Sale with ID {SaleId} not found.", request.SaleId);
            }
            return sale == null ? null : _mapper.Map<SaleDTO>(sale);
        }
    }
}
