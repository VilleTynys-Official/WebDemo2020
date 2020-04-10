using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AspNetWebDemo.Models;
using AspNetWebDemo.Tietokanta;

namespace AspNetWebDemo.Controllers
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
            return View();
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

        public string OmaJuttu()
        {
            return "Moro, täällä ollaan!";
        }

        public string Kellonaika()
        {
            return DateTime.Now.ToString();
        }



        public IActionResult UusiSivu()
        {
            List<Asiakas> asiakkaat = new List<Asiakas>()
            {
                new Asiakas()
                {
                    AsiakasId = 100,
                    AsiakkaanNimi = "Yritys Oy",
                    Sähköpostiosoite = "info@yritys.fi"
                },
                new Asiakas()
                {
                    AsiakasId = 101,
                    AsiakkaanNimi = "Asiakas Oy",
                    Sähköpostiosoite = "info@asiakas.fi"
                },
                new Asiakas()
                {
                    AsiakasId = 102,
                    AsiakkaanNimi = "Testaus Oy",
                    Sähköpostiosoite = "info@testaus.com"
                }
            };

            ViewBag.NapinVäri = "danger";
            ViewBag.NäytäLista = false;

            return View(asiakkaat);
        }



        //hyödynnetään tietokanta-olioita. Miinuksena muistinkulutus..     
        public IActionResult AsiakasListaus()
        {
            NorthwindContext konteksti = new NorthwindContext();


            //haetaan kaikki asiakkaat
            //List<Customers> asiakkaat = konteksti.Customers.ToList();


            //esimerkki LINQ:lla: QUERY SYNTAX:
            List<Customers> asiakkaat = (from a in konteksti.Customers
                                        where a.Country == "Finland"
                                        select a).ToList();                     //mitä ikinä saadaankaan niin muutetaan listaksi (helppo kuljettaa näkymään)

            //esimerkki LINQ:lla: METHOD SYNTAX:
            List<Customers> asiakkaat2 = konteksti.Customers.Where(             //hyödynnetään lambda lauseita yms., käytännössä sama kuin yläpuolella.
                a => a.Country == "Finland").ToList();

            return View(asiakkaat);
            //return View(asiakkaat2);
        }
    }
}