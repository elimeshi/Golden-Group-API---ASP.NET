using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using GoldenGroupAPI.Data;
using GoldenGroupAPI.Models;

namespace GoldenGroupAPI.Repositories
{
    public class ListingRepository : IListingRepository
    {
        private readonly GoldenGroupDbContext _context;

        public ListingRepository(GoldenGroupDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Listing>> GetAllAsync()
        {
            return await _context.Listings
                .Include(l => l.HousingUnits)
                .Include(l => l.Client)
                .ToListAsync();
        }

        public async Task<Listing?> GetByIdAsync(int id)
        {
            return await _context.Listings
                .Include(l => l.HousingUnits)
                .Include(l => l.Client)
                .FirstOrDefaultAsync(l => l.Id == id);
        }

        public async Task<Listing> AddAsync(Listing listing)
        {
            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();
            return listing;
        }

        public async Task UpdateAsync(Listing listing)
        {
            _context.Entry(listing).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var listing = await _context.Listings.FindAsync(id);
            if (listing != null)
            {
                _context.Listings.Remove(listing);
                await _context.SaveChangesAsync();
            }
        }
    }
}
