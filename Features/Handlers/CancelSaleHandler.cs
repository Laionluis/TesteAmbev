using MediatR;
using TesteAmbev.Features.Commands;
using TesteAmbev.Repositories.Interfaces;

namespace TesteAmbev.Features.Handlers
{
    public class CancelSaleHandler : IRequestHandler<CancelSaleCommand, Unit>
    {
        private readonly ISaleRepository _repository;

        public CancelSaleHandler(ISaleRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CancelSaleCommand request, CancellationToken cancellationToken)
        {
            var sale = await _repository.GetByIdAsync(request.SaleId);
            if (sale == null) throw new Exception("Sale not found");
            sale.IsCancelled = true;
            await _repository.UpdateAsync(sale);
            return Unit.Value;
        }
    }
}
