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
        public async Task<List<RegistroDeVenda>> EncontrarPorDataAsync(DateTime? MinDate, DateTime? MaxDate)
        {
            var selecione = from obj in _context.RegistroDeVenda select obj;

            if (MinDate.HasValue)
            {
                selecione = selecione.Where(x => x.Data >= MinDate.Value);
            }
            if (MaxDate.HasValue)
            {
                selecione = selecione.Where(x => x.Data <= MaxDate.Value);
            }

            return await selecione.
                Include(x => x.Vendedor).
                Include(x => x.Vendedor.Departamento).
                OrderByDescending(x => x.Data).
                ToListAsync();
        }

    }
}

