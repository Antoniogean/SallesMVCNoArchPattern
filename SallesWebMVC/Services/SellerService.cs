using Microsoft.EntityFrameworkCore;
using SallesWebMVC.Data;
using SallesWebMVC.Models;

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
    }
}
