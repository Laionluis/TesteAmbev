using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TesteAmbev.Data;
using TesteAmbev.DTOs;
using TesteAmbev.Features.Querys;

namespace TesteAmbev.Features.Handlers
{
    public class GetSalesHandler : IRequestHandler<GetSalesQuery, List<SaleDTO>>
    {
        private readonly SalesDbContext _context;
        private readonly IMapper _mapper;
        private readonly ILogger<GetSalesHandler> _logger;

        public GetSalesHandler(SalesDbContext context, IMapper mapper, ILogger<GetSalesHandler> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<SaleDTO>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Fetching sales with pagination: Page {Page}, PageSize {PageSize}", request.Page, request.PageSize);
            var sales = await _context.Sales
                .Include(s => s.Items)
                .OrderByDescending(s => s.SaleDate)
                .Skip((request.Page - 1) * request.PageSize)
                .Take(request.PageSize)
                .ToListAsync();

            return _mapper.Map<List<SaleDTO>>(sales);
        }
    }
}
