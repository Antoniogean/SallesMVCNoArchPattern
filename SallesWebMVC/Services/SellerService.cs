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
    }
}
