using VendasWebMvc.Data;
using VendasWebMvc.Models;
using Microsoft.EntityFrameworkCore;
using VendasWebMvc.Services.Exceções;

namespace VendasWebMvc.Services
{
    public class VendedorServicos
    {
        private readonly VendasWebMvcContext _context;

        public VendedorServicos(VendasWebMvcContext context)
        {
            _context = context;
        }

        public async Task<List<Vendedor>> FindAllAsync()
        {
            return await _context.Vendedor.ToListAsync();
        }
        public async Task AddVendedorAsync(Vendedor v)
        {

            _context.Vendedor.Add(v);

          await  _context.SaveChangesAsync();
        }
        //metodo encontrarId
        public async Task<Vendedor> EncontrarIdAsync(int Id)
        {
            return await _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefaultAsync(obj => obj.Id == Id);
        }

        //metodo Remover
        public async Task RemoverAsync(int Id)
        {
            var encontrar = await _context.Vendedor.FindAsync(Id);
            _context.Vendedor.Remove(encontrar);
           await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Vendedor Obj)
        {
            var i = await _context.Vendedor.AnyAsync(x => x.Id == Obj.Id);
            if (!i)
            {
                throw new NotFoundException("Not Found");
            }
            try
            {
                _context.Update(Obj);
               await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
