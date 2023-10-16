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
using ZstdSharp.Unsafe;

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
        public async Task<IActionResult> Index()
        {
            var todosVendedores = await _vendedorServicos.FindAllAsync();
            var todosDepartamentos = await _departamentosServicos.FindAllAsync();
            var Departamentos = todosDepartamentos.ToDictionary(x => x.Id, x => x.Name);
            ViewData["Departamentos"] = Departamentos;
            return View(todosVendedores);
        }

        public async Task<IActionResult> Create()
        {
            var todosDepartamentos = await _departamentosServicos.FindAllAsync();
            ViewBag.Departamentos = new SelectList(todosDepartamentos, "Id", "Name");

            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create(Vendedor vendedor)
        {
                await _vendedorServicos.AddVendedorAsync(vendedor);

                return RedirectToAction(nameof(Index));
            
         
        }


        public async Task<IActionResult> Delete(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não fornecido" });
            }
            var obj = await _vendedorServicos.EncontrarIdAsync(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não encontrado" });
            }
            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int Id)
        {
          await  _vendedorServicos.RemoverAsync(Id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Details(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não fornecido" });
            }
            var obj = await _vendedorServicos.EncontrarIdAsync(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não encontrado" });
            }


            return View(obj);

        }
        public async Task<IActionResult> Edit(int? Id)
        {
            if (Id == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não fornecido" });
            }
            var obj = await _vendedorServicos.EncontrarIdAsync(Id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { Message = "ID não encontrado" });
            }

            List<Departamento> departamentos = await _departamentosServicos.FindAllAsync();
            DepartamentoViewModel viewModel = new DepartamentoViewModel { Vendedor = obj, Departamentos = departamentos };
            return View(viewModel);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Vendedor vendedor)
        {
       
            if (id != vendedor.Id)
            {
                return RedirectToAction(nameof(Error), new { Message = "Id incompatível" });
            }
            try
            {
                await _vendedorServicos.UpdateAsync(vendedor);
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
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(ViewModel);
        }
    }

}


