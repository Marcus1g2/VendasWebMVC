namespace VendasWebMvc.Models
{
    public class Departamento
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Vendedor> Vendedores { get; set; } = new List<Vendedor>();

        public Departamento()
        {

        }

        public Departamento(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void AddVendedores(Vendedor vendedores)
        {
            Vendedores.Add(vendedores);
        }

        public double TotalVendas(DateTime Inicial, DateTime Final)
        {
            return Vendedores.Sum(vd => vd.TotalVendas(Inicial, Final));
        }
    }
}
