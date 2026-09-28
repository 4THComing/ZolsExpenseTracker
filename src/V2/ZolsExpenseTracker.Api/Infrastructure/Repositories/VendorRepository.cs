using Microsoft.EntityFrameworkCore;
using ZolsExpenseTracker.Api.Models;
using ZolsExpenseTracker.Api.Infrastructure.Data;

namespace ZolsExpenseTracker.Api.Infrastructure.Repositories
{
    public class VendorRepository : IVendorRepository

    {
        private readonly ExpenseDbContext _context;

        public VendorRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Vendor>> GetAllVendors()
        {
            return await _context.Vendors.ToListAsync();
        }

        public async Task<Vendor?> GetVendorByIdAsync(Guid id)
        {
            return await _context.Vendors.FindAsync(id);
        }

        public async Task AddVendorAsync(Vendor vendor)
        {
            await _context.Vendors.AddAsync(vendor);
        }

        public async Task UpdateVendor(Vendor vendor)
        {
            _context.Vendors.Update(vendor);
        }

        public async Task DeleteVendor(Vendor vendor)
        {
            _context.Vendors.Remove(vendor);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    } 

}       