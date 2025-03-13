using AutoMapper;
using MediatR;
using TesteAmbev.DTOs;
using TesteAmbev.Features.Commands;
using TesteAmbev.Models;
using TesteAmbev.Repositories.Interfaces;

namespace TesteAmbev.Features.Handlers
{
    public class CreateSaleHandler : IRequestHandler<CreateSaleCommand, SaleDTO>
    {
        private readonly ISaleRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CreateSaleHandler> _logger;

        public CreateSaleHandler(ISaleRepository repository, IMapper mapper, ILogger<CreateSaleHandler> logger)
        {
            _repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<SaleDTO> Handle(CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = _mapper.Map<Sale>(request.Sale);
            sale.Id = Guid.NewGuid();
            sale.SaleDate = DateTime.UtcNow;
            sale.TotalAmount = sale.Items.Sum(item => ApplyDiscount(item));
            await _repository.AddAsync(sale);
            _logger.LogInformation("Sale Created: {SaleId}", sale.Id);
            return _mapper.Map<SaleDTO>(sale);
        }

        private decimal ApplyDiscount(SaleItem item)
        {
            if (item.Quantity >= 10 && item.Quantity <= 20)
                item.Discount = 0.20m;
            else if (item.Quantity >= 4)
                item.Discount = 0.10m;
            else
                item.Discount = 0.00m;

            return (item.UnitPrice * item.Quantity) * (1 - item.Discount);
        }
    }
}
