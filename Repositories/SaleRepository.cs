using Microsoft.EntityFrameworkCore;
using TesteAmbev.Data;
using TesteAmbev.Models;
using TesteAmbev.Repositories.Interfaces;

namespace TesteAmbev.Repositories
{
    public class SaleRepository : ISaleRepository
    {
        private readonly SalesDbContext _context;
        public SaleRepository(SalesDbContext context)
        {
            _context = context;
        }
        public async Task<List<Sale>> GetAllAsync() => await _context.Sales.Include(s => s.Items).ToListAsync();
        public async Task<Sale> GetByIdAsync(Guid id) => await _context.Sales.Include(s => s.Items).FirstOrDefaultAsync(s => s.Id == id);
        public async Task<Sale> AddAsync(Sale sale)
        {
            _context.Sales.Add(sale);
            await _context.SaveChangesAsync();
            return sale;
        }
        public async Task UpdateAsync(Sale sale)
        {
            _context.Sales.Update(sale);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Sale sale)
        {
            _context.Sales.Remove(sale);
            await _context.SaveChangesAsync();
        }
    }
}
