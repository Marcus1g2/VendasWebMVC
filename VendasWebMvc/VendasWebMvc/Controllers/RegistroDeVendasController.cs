using Microsoft.AspNetCore.Mvc;
using VendasWebMvc.Services;

namespace VendasWebMvc.Controllers
{
    public class RegistroDeVendasController : Controller
    {
        private readonly RegistroDeVendaServicos _Rvd;

        public RegistroDeVendasController(RegistroDeVendaServicos rvd)
        {
            _Rvd = rvd;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> BuscaSimples(DateTime? MinDate, DateTime? MaxDate)
        {
            if(!MinDate.HasValue)
            {
                MinDate = new DateTime(DateTime.Now.Year,1,1);
            }
            if(!MaxDate.HasValue)
            {
                MaxDate = new DateTime(DateTime.Now.Year);
            }
            ViewData["minDate"] =MinDate.Value.ToString("dd/MM/yyyy");
            ViewData["maxDate"]=MaxDate.Value.ToString("dd/MM/yyyy");
            

            var mostrar = await _Rvd.EncontrarPorDataAsync(MinDate, MaxDate);

            return View(mostrar);
        }
        public IActionResult BuscaAgrupada()
        {
            return View();
        }
    }
}
