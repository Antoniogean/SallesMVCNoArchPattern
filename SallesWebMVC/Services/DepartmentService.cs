using SallesWebMVC.Data;
using SallesWebMVC.Models;

namespace SallesWebMVC.Services
{
    public class DepartmentService
    {
        private readonly SallesWebMVCContext _context;

        public DepartmentService(SallesWebMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy( x=> x.Name).ToList();
        }
    }
}
