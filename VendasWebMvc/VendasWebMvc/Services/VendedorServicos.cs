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

        public List<Vendedor> MostraV()
        {
            return _context.Vendedor.ToList();
        }
        public void AddVendedor(Vendedor v)
        {

            _context.Vendedor.Add(v);

            _context.SaveChanges();
        }
        //metodo encontrarId
        public Vendedor EncontrarId(int Id)
        {
            return _context.Vendedor.Include(obj => obj.Departamento).FirstOrDefault(obj => obj.Id == Id);
        }

        //metodo Remover
        public void Remover(int Id)
        {
            var encontrar = _context.Vendedor.Find(Id);
            _context.Vendedor.Remove(encontrar);
            _context.SaveChanges();
        }

        public void Update(Vendedor Obj)
        {
            if (!_context.Vendedor.Any(x => x.Id == Obj.Id))
            {
                throw new NotFoundException("Not Found");
            }
            try
            {
                _context.Update(Obj);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
