using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoldenGroupAPI.Data;
using GoldenGroupAPI.Models;

namespace GoldenGroupAPI.Repositories
{
    public class BuyerRequestRepository : IBuyerRequestRepository
    {
        private readonly GoldenGroupDbContext _context;

        public BuyerRequestRepository(GoldenGroupDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<BuyerRequest>> GetAllAsync()
        {
            return await _context.BuyerRequests
                .Include(br => br.Client)
                .ToListAsync();
        }

        public async Task<BuyerRequest?> GetByIdAsync(int id)
        {
            return await _context.BuyerRequests
                .Include(br => br.Client)
                .FirstOrDefaultAsync(br => br.Id == id);
        }

        public async Task<BuyerRequest> AddAsync(BuyerRequest request)
        {
            _context.BuyerRequests.Add(request);
            await _context.SaveChangesAsync();
            return request;
        }

        public async Task UpdateAsync(BuyerRequest request)
        {
            _context.Entry(request).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var request = await _context.BuyerRequests.FindAsync(id);
            if (request != null)
            {
                _context.BuyerRequests.Remove(request);
                await _context.SaveChangesAsync();
            }
        }
    }
}
