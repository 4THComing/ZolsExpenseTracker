using ZolsExpenseTracker.Core.Models;
using ZolsExpenseTracker.Core.Interfaces;
using ZolsExpenseTracker.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public class VendorProfileRepository : IVendorProfileRepository
    {
        private readonly ExpenseDbContext _context;
        public VendorProfileRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<List<VendorProfile>> GetAllAsync() 
        => await _context.VendorProfiles.ToListAsync();

        public async Task<VendorProfile?> GetByIdAsync(Guid id)
        => await _context.VendorProfiles.FindAsync(id);

        public async Task<VendorProfile> AddAsync(VendorProfile vendorProfile)
        {
            var vp = await _context.VendorProfiles.AddAsync(vendorProfile);
            await _context.SaveChangesAsync();
            return vp.Entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.VendorProfiles.FindAsync(id);
            if (entity != null)
            {
                _context.VendorProfiles.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }

    }
}