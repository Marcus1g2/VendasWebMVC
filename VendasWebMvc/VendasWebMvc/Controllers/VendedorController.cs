using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Data;
using VendasWebMvc.Models;
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
            var todosVendedores = _vendedorServicos.MostraV();
            return View(todosVendedores);
        }
       
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Vendedor vendedor)
        {
           _vendedorServicos.AddVendedor(vendedor);

            return RedirectToAction(nameof(Index));
        } 
        


    }
}
