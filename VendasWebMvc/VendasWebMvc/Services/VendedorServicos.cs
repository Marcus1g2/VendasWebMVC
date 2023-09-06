using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class VendedorServicos
    {
       private readonly VendasWebMvcContext _context;
        public VendedorServicos(VendasWebMvcContext context)
        {
            _context = context;
        }
        public List<Vendedor> MostraV()
        {
            return _context.Vendedor.ToList();
        }
    }
}
