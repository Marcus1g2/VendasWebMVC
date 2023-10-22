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
        public async Task<IActionResult> BuscaSimples(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("dd/MM/yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd/MM/yyyy");


            var mostrar = await _Rvd.BuscaSimplesAsync(minDate, maxDate);

            return View(mostrar);
        }

        public async Task<IActionResult> BuscaAgrupada(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate=new DateTime(DateTime.Now.Year,1, 1);
            }
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            ViewData["minDate"] = minDate.Value.ToString("dd/MM/yyyy");
            ViewData["maxDate"] = maxDate.Value.ToString("dd/MM/yyyy");

            var datas=await _Rvd.BuscaAgrupadaAsync(minDate, maxDate);
            return View(datas);
        }

    }
}

