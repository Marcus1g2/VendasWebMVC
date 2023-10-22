using Microsoft.EntityFrameworkCore;
using NuGet.ProjectModel;
using VendasWebMvc.Data;
using VendasWebMvc.Models;

namespace VendasWebMvc.Services
{
    public class RegistroDeVendaServicos
    {
        private readonly VendasWebMvcContext _context;

        public RegistroDeVendaServicos(VendasWebMvcContext context)
        {
            _context = context;
        }
        public async Task<List<RegistroDeVenda>> BuscaSimplesAsync(DateTime? minDate, DateTime? maxDate)
        {
            var selecione = from obj in _context.RegistroDeVenda select obj;

            if (minDate.HasValue)
            {
                selecione = selecione.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                selecione = selecione.Where(x => x.Data <= maxDate.Value);
            }

            return await selecione.
                Include(x => x.Vendedor).
                Include(x => x.Vendedor.Departamento).
                OrderByDescending(x => x.Data).
                ToListAsync();
        }
        public async Task<List<IGrouping<Departamento, RegistroDeVenda>>> BuscaAgrupadaAsync(DateTime? minDate, DateTime? maxDate)
        {
            var select = from obj in _context.RegistroDeVenda select obj;
            if (minDate.HasValue)
            {
                select = select.Where(x => x.Data >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                select = select.Where(x => x.Data <= maxDate.Value);
            }
            return await select.Include(x => x.Vendedor).
                Include(x => x.Vendedor.Departamento).
                OrderByDescending(x => x.Data).
                GroupBy(x => x.Vendedor.Departamento).
                ToListAsync();
        }

    }
}












