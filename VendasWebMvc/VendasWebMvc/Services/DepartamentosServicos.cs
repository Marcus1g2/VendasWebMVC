using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class DepartamentosServicos
    {
        private readonly VendasWebMvcContext _context;

        public DepartamentosServicos(VendasWebMvcContext context)
        {
            _context = context;
        }
        public List<Departamento> MostraD()
        {
            return _context.Departamento.OrderBy(x=>x.Id).ToList();
        }
    }
}
