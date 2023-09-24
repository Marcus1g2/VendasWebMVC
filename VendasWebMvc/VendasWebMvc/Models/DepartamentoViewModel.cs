namespace VendasWebMvc.Models
{
    public class DepartamentoViewModel
    {
        public Vendedor Vendedor { get; set; }
        public ICollection<Departamento> Departamentos { get; set; }
    }
}
