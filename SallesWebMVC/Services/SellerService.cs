using Microsoft.EntityFrameworkCore;
using SallesWebMVC.Data;
using SallesWebMVC.Models;
using SallesWebMVC.Services.Exceptions;
using System.Data;

namespace SallesWebMVC.Services
{
    public class SellerService
    {
        private readonly SallesWebMVCContext _context;

        public SellerService(SallesWebMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void InsertSeller(Seller seller)
        {
            _context.Add(seller);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
            return _context.Seller.Include(s => s.Department).FirstOrDefault(obj => obj.Id == id);
        }

        public void DeleteSeller(int id)
        {
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
        }

        public void UpdateSeller(Seller seller)
        {
            if (!_context.Seller.Any(obj => obj.Id == seller.Id))
            {
                throw new NotFoundException("Not found id");
            }

            try
            {
                _context.Update(seller);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcunrrencyExpcetion(e.Message);
            }
        }
    }
}
