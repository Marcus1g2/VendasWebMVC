using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Departamento>> FindAllAsync()
        {
            return await _context.Departamento.OrderBy(x=>x.Id).ToListAsync();
        }
    }
}
