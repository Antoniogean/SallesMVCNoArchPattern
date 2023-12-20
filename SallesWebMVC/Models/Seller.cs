using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SallesWebMVC.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }


        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display( Name = "Data de aniversário")]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set;}

        [Display(Name = "Salário base")]
        [DataType(DataType.Currency)]
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public ICollection<SalesRecord> SalesRecords { get; set; } = new List<SalesRecord>();

        public Seller()
        {
        }

        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            BaseSalary = baseSalary;
            Department = department;
        }

        public void AddSales(SalesRecord record)
        {
            SalesRecords.Add(record);
        }

        public double TotalSales(DateTime initialDate, DateTime finalDate) 
        {
            return SalesRecords.Where(records => records.Date >= initialDate && records.Date <= finalDate).Sum(records => records.Amount);
        }
    }
}
