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
        public IActionResult AsiakasListaus(string id)
        {
            NorthwindContext konteksti = new NorthwindContext();
            List<Customers> asiakkaat;

            if (string.IsNullOrEmpty(id))
            {
                asiakkaat = konteksti.Customers.ToList();               // jos id on tyhjä hakee kaikki Customerit listaksi
            }
            else
            {
                string maa = id;
                asiakkaat = (from a in konteksti.Customers              // jos id ei ole tyhjä, haetaan asiakkaat joiden id täsmää.
                             where a.Country == maa
                             select a).ToList();
            };



            return View(asiakkaat);
        }
    }
}