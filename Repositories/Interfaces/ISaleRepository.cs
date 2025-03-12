using TesteAmbev.Models;

namespace TesteAmbev.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAllAsync();
        Task<Sale> GetByIdAsync(Guid id);
        Task<Sale> AddAsync(Sale sale);
        Task UpdateAsync(Sale sale);
        Task DeleteAsync(Sale sale);
    }
}
