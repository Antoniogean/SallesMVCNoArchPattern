using SallesWebMVC.Models.Enum;

namespace SallesWebMVC.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date{ get; set; }
        public double Amount { get; set; }
        public SaleStatus Stauts { get; set; }
        public Seller Seller { get; set; }

        public SalesRecord()
        {
        }

        public SalesRecord(int id, DateTime date, double amount, SaleStatus stauts, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Stauts = stauts;
            Seller = seller;
        }
    }
}
