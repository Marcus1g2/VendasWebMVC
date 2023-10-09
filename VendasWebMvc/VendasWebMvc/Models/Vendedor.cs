namespace VendasWebMvc.Models
{
    public class Vendedor
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public double Salario { get; set; }
        public ICollection<RegistroDeVenda> registroDeVendas { get; set; } = new List<RegistroDeVenda>();
        public Departamento Departamento { get; set; }
        public int DepartamentoId { get; set; }
        public Vendedor()
        {
            Nome = "";
        }

        public Vendedor(int id, string nome, DateTime data, double salario, Departamento departamento)
        {
            Id = id;
            Nome = nome;
            Data = data;
            Salario = salario;
            Departamento = departamento;

        }
        public void AddRegistro(RegistroDeVenda registroDeVenda)
        {
            registroDeVendas.Add(registroDeVenda);
        }
        public void RemoveRegistro(RegistroDeVenda registroDeVenda)
        {
            registroDeVendas.Remove(registroDeVenda);
        }
        public double TotalVendas(DateTime Inicial, DateTime Final)
        {
            return registroDeVendas.Where(rv => rv.Data <= Inicial && rv.Data >= Final).Sum(rv => rv.Montante); // Registro de vendas junta dinheiro durante esse periodo
        }

    }
}
