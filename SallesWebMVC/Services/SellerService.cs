using Microsoft.EntityFrameworkCore;
using SallesWebMVC.Data;
using SallesWebMVC.Models;
using SallesWebMVC.Services.Exceptions;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace SallesWebMVC.Services
{
    public class SellerService
    {
        private readonly SallesWebMVCContext _context;

        public SellerService(SallesWebMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync()
        {
            return await _context.Seller.ToListAsync();
        }

        public async Task InsertSellerAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id)
        {
            return await _context.Seller.Include(s => s.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        public async Task DeleteSellerAsync(int id)
        {
            var obj = await _context.Seller.FindAsync(id);
            _context.Seller.Remove(obj);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSellerAsync(Seller seller)
        {
            if (!await _context.Seller.AnyAsync(obj => obj.Id == seller.Id))
            {
                throw new NotFoundException("Not found id");
            }

            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcunrrencyExpcetion(e.Message);
            }
        }
    }
}
