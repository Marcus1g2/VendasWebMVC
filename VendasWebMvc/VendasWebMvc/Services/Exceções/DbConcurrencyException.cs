namespace VendasWebMvc.Services.Exceções
{
    public class DbConcurrencyException :ApplicationException
    {
        public DbConcurrencyException (string message):base(message) { }
    }
}
