using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using VendasWebMvc.Data;
using VendasWebMvc.Models;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class VendedorController : Controller
    {
        private readonly VendedorServicos _vendedorServicos;
        private readonly DepartamentosServicos _departamentosServicos;

        public VendedorController(VendedorServicos vendedorServicos, DepartamentosServicos departamentosServicos)
        {
            _vendedorServicos = vendedorServicos;
            _departamentosServicos = departamentosServicos;

        }
            public IActionResult Index()
            {
                var todosVendedores = _vendedorServicos.MostraV();
                var todosDepartamentos = _departamentosServicos.MostraD();
                var Departamentos = todosDepartamentos.ToDictionary(x => x.Id, x => x.Name);
                ViewData["Departamentos"] = Departamentos;
                return View(todosVendedores);
            }

            public IActionResult Create()
            {
                var todosDepartamentos = _departamentosServicos.MostraD();
                ViewBag.Departamentos = new SelectList(todosDepartamentos, "Id", "Name");

                return View();
            }



            [HttpPost]
            [ValidateAntiForgeryToken]

            public IActionResult Create(Vendedor vendedor)
            {

                _vendedorServicos.AddVendedor(vendedor);

                return RedirectToAction(nameof(Index));
            }

     public IActionResult Delete(int ? Id)
        {
            if(Id==null)
            {
                return NotFound();
            }
            var obj = _vendedorServicos.EncontrarId(Id.Value);
                if (obj == null)
            {
                return NotFound();
            }
                return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int Id)
        {
            _vendedorServicos.Remover(Id);
            return RedirectToAction(nameof(Index));
        }

        } 
    }
    

