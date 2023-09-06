using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Data;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class VendedorController : Controller
    {
      private readonly VendedorServicos _vendedorServicos;
        public VendedorController(VendedorServicos vendedorServicos)
        {
            _vendedorServicos = vendedorServicos;
        }


        public IActionResult Index()
        {
           var Mostrar = _vendedorServicos.MostraV();
            return View(Mostrar);
        }
    }
}
