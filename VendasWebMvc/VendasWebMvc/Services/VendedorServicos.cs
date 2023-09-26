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
        public void AddVendedor(Vendedor v)
        {
       
            _context.Vendedor.Add(v);

            _context.SaveChanges();
        }
        //metodo encontrarId
    public Vendedor EncontrarId(int Id)
        {
            return _context.Vendedor.FirstOrDefault(obj=>obj.Id==Id); 
        }

        //metodo Remover
      public void Remover(int Id)
        {
           var encontrar = _context.Vendedor.Find(Id);
            _context.Vendedor.Remove(encontrar);
            _context.SaveChanges();
        }
     
        
    }
}
