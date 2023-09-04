using VendasWebMvc.Models;
using VendasWebMvc.Models.Enums;
namespace VendasWebMvc.Data
{
    public class ServicoDeSedding
    {
        private VendasWebMvcContext _context;

        public ServicoDeSedding (VendasWebMvcContext context)
        {
            _context = context;
        }
        public void teste()
        {
            if (_context.Departamento.Any() || _context.Vendedor.Any() || _context.RegistroDeVenda.Any() )
            {
                return;
            }

            Departamento D1 = new Departamento(1, "Computadores");
             Departamento D2 = new Departamento(2, "Eletronicos");
              Departamento D3 = new Departamento(3, "Moda");
            Vendedor V1 = new Vendedor(1, "Alberto", new DateTime(1998, 09, 23), 1200.0,D1);
            Vendedor V2 = new Vendedor(2, "Francisco", new DateTime(1995, 09, 23),1200.0, D2);
            Vendedor V3 = new Vendedor(3, "Lucas", new DateTime(1991, 09, 23),1200.0, D2);
            RegistroDeVenda G1= new RegistroDeVenda(1,new DateTime(2022,05,11),22000, StatusVenda.Finalizado, V1);
            RegistroDeVenda G2= new RegistroDeVenda(2,new DateTime(2020,06,01),22500, StatusVenda.Finalizado, V2);
            RegistroDeVenda G3= new RegistroDeVenda(3,new DateTime(2019,05,11),1500, StatusVenda.Finalizado, V3);
            
            _context.Departamento.AddRange(D1,D2, D3);
            _context.Vendedor.AddRange(V1, V2, V3);
            _context.RegistroDeVenda.AddRange(G1, G2, G3);

            _context.SaveChanges();

            
        }

    }
}
