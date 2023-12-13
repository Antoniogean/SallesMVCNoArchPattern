namespace SallesWebMVC.Services.Exceptions
{
    public class DbConcunrrencyExpcetion : ApplicationException
    {
        public DbConcunrrencyExpcetion(string message) : base() { }
    }
}
