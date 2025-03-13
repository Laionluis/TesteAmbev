using MediatR;
using TesteAmbev.Features.Commands;
using TesteAmbev.Repositories.Interfaces;

namespace TesteAmbev.Features.Handlers
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, Unit>
    {
        private readonly ISaleRepository _repository;
        private readonly ILogger<CancelSaleHandler> _logger;

        public CancelSaleHandler(ISaleRepository repository, ILogger<CancelSaleHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Unit> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.SaleId);
            if (sale == null)
            {
                _logger.LogWarning("Sale with ID {SaleId} not found.", request.SaleId);
                return Unit.Value;
            }
            sale.IsCancelled = true;
            await _repository.UpdateAsync(sale);
            _logger.LogInformation("Sale Cancelled: {SaleId}", request.SaleId);
            return Unit.Value;
        }
    }
}
