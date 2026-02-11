using System.Collections.Generic;
using System.Threading.Tasks;
using GoldenGroupAPI.Models;

namespace GoldenGroupAPI.Repositories
{
    public interface IClientRepository
    {
        Task<IEnumerable<Client>> GetAllAsync();
        Task<Client?> GetByIdAsync(int id);
        Task<Client> AddAsync(Client client);
        Task UpdateAsync(Client client);
        Task DeleteAsync(int id);
    }

    public interface IListingRepository
    {
        Task<IEnumerable<Listing>> GetAllAsync();
        Task<Listing?> GetByIdAsync(int id);
        Task<Listing> AddAsync(Listing listing);
        Task UpdateAsync(Listing listing);
        Task DeleteAsync(int id);
    }

    public interface IBuyerRequestRepository
    {
        Task<IEnumerable<BuyerRequest>> GetAllAsync();
        Task<BuyerRequest?> GetByIdAsync(int id);
        Task<BuyerRequest> AddAsync(BuyerRequest request);
        Task UpdateAsync(BuyerRequest request);
        Task DeleteAsync(int id);
    }
}
