using ZolsExpenseTracker.Api.Models;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public interface IVendorRepository
    {
        Task<IEnumerable<Vendor>> GetAllVendors();
        Task<Vendor?> GetVendorByIdAsync( Guid id );
        Task AddVendorAsync(Vendor vendor);
        Task UpdateVendor(Vendor vendor);
        Task DeleteVendor(Vendor vendor);
        Task SaveChangesAsync();
    }
}