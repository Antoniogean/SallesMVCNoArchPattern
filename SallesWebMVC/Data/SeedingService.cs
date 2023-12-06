using SallesWebMVC.Models;

namespace SallesWebMVC.Data
{
    public class SeedingService
    {
        private SallesWebMVCContext _context;

        public SeedingService(SallesWebMVCContext sallesWebMVCContext)
        {
            _context = sallesWebMVCContext;
        }

        public void Seed()
        {
            if (_context.Department.Any() || _context.Seller.Any() || _context.SalesRecord.Any()) return;

            Department department1 = new Department(1, "Roupas masculinas");
            Department department2 = new Department(2, "Roupas infantis");
            Department department3 = new Department(3, "Roupas femininas");
            Department department4 = new Department(4, "Roupas neutres");

            Seller seller1 = new Seller(1, "Bob", "bob@gmail.com", new DateTime(1993, 10, 27), 1200, department1);
            Seller seller2 = new Seller(2, "Bob1", "bo1b@gmail.com", new DateTime(1993, 10, 27), 1200, department2);
            Seller seller3 = new Seller(3, "Bob2", "bob2@gmail.com", new DateTime(1993, 10, 27), 1200, department3);
            Seller seller4 = new Seller(4, "Bob3", "bob3@gmail.com", new DateTime(1993, 10, 27), 1200, department3);
            Seller seller5 = new Seller(5, "Bob4", "bob4@gmail.com", new DateTime(1993, 10, 27), 1200, department4);

            SalesRecord sallesRecord1 = new SalesRecord(1, new DateTime(2023, 12, 1), 12.3, Models.Enum.SaleStatus.Billed, seller1);
            SalesRecord sallesRecord2 = new SalesRecord(2, new DateTime(2023, 12, 1), 12.3, Models.Enum.SaleStatus.Billed, seller2);
            SalesRecord sallesRecord3 = new SalesRecord(3, new DateTime(2023, 12, 1), 12.3, Models.Enum.SaleStatus.Billed, seller3);
            SalesRecord sallesRecord4 = new SalesRecord(4, new DateTime(2023, 12, 1), 12.3, Models.Enum.SaleStatus.Billed, seller4);
            SalesRecord sallesRecord5 = new SalesRecord(5, new DateTime(2023, 12, 1), 12.3, Models.Enum.SaleStatus.Billed, seller5);
            SalesRecord sallesRecord6 = new SalesRecord(6, new DateTime(2023, 12, 1), 12.3, Models.Enum.SaleStatus.Billed, seller1);

            _context.Department.AddRange(department1, department2, department3, department4);
            _context.Seller.AddRange(seller1,seller2, seller3, seller4, seller5);
            _context.SalesRecord.AddRange(sallesRecord1, sallesRecord2, sallesRecord3, sallesRecord4, sallesRecord5, sallesRecord6);

            _context.SaveChanges();    
        }
    }
}
