using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplicationCV.Models;
using ConsoleAppCV;

namespace WebApplicationCV.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            
            InformazioniPersonali info = new InformazioniPersonali("Mario", "Rossi", "1234567890", "mario.rossi@example.com");

            List<Studi> studi = new List<Studi>
            {
                new Studi("Master in Ingegneria del Software", "Politecnico di Milano", "Master", new DateOnly(2018, 10, 1), new DateOnly(2020, 5, 30)),
                new Studi("Laurea in Informatica", "Università di Roma", "Laurea", new DateOnly(2015, 9, 1), new DateOnly(2018, 7, 15))
            };

            List<Impiego> impieghi = new List<Impiego>
            {
                new Impiego(new Esperienza("Innovatech", "Senior Developer", new DateOnly(2020, 7, 1), new DateOnly(2023, 6, 30), "Progettazione e sviluppo di soluzioni software", "Coordinamento del team di sviluppo")),
                new Impiego(new Esperienza("TechCompany", "Software Developer", new DateOnly(2018, 8, 1), new DateOnly(2020, 6, 30), "Sviluppo software", "Analisi, sviluppo e test di applicazioni software"))
            };

            CV mioCV = new CV(info, studi, impieghi);

            
            return View(mioCV);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
