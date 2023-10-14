using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Diagnostics;
using VendasWebMvc.Data;
using VendasWebMvc.Models;
using VendasWebMvc.Services;
using VendasWebMvc.Services.Exceções;

namespace VendasWebMvc.Controllers
{
    public class VendedorController : Controller

    {
        private readonly VendasWebMvcContext _context;
        private readonly VendedorServicos _vendedorServicos;
        private readonly DepartamentosServicos _departamentosServicos;

        public VendedorController(VendasWebMvcContext context, VendedorServicos vendedorServicos, DepartamentosServicos departamentosServicos)
        {
            _context = context;
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
            if (!ModelState.IsValid)
            {
                var departamento = _departamentosServicos.MostraD();
                var viewModel = new DepartamentoViewModel { Vendedor = vendedor, Departamentos = departamento };
                return View(viewModel);
            }
            _vendedorServicos.AddVendedor(vendedor);

            return RedirectToAction(nameof(Index));
        }


        public IActionResult Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não fornecido" });
            }
            var obj = _vendedorServicos.EncontrarId(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não encontrado" });
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
        public IActionResult Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não fornecido" });
            }
            var obj = _vendedorServicos.EncontrarId(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não encontrado" });
            }


            return View(obj);

        }
        public IActionResult Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não fornecido" });
            }
            var obj = _vendedorServicos.EncontrarId(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não encontrado" });
            }

            List<Departamento> departamentos = _departamentosServicos.MostraD();
            DepartamentoViewModel viewModel = new DepartamentoViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Vendedor vendedor)
        {
            if (!ModelState.IsValid)
            {
                var departamento = _departamentosServicos.MostraD();
                var viewModel = new DepartamentoViewModel { Vendedor = vendedor, Departamentos = departamento };
                return View(viewModel);
            }
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id incompatível" });
            }
            try
            {
                _vendedorServicos.Update(vendedor);
                return RedirectToAction(nameof(Index));
            }
            catch (ApplicationException e)
            {
                return RedirectToAction(nameof(Error), new { Message = e.Message });
            }
          
        }
        public IActionResult Error(string message)
        {
            var ViewModel = new ErrorViewModel
            {
                Message = message,
                RequestId = Activity.Current?.Id??HttpContext.TraceIdentifier
            };
            return View(ViewModel);
        }
    }

}


