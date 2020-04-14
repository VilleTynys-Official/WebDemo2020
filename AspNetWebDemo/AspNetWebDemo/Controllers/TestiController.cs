using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetWebDemo.Models;
using AspNetWebDemo.Tietokanta;

namespace AspNetWebDemo.Controllers
{
    [Route("api/[controller]")]                         //atribuutit jotka auttavat api ohjelmia.
    [ApiController]
    public class TestiController : ControllerBase
    {


        [Route("eka")]                              ///     huom. reititys muuttaa URL osoitetta:     /api/testi/eka
        public string Eka()
        {

            return "hello world";
        }

        [Route("toka")]
        public string Toka()
        {
            return "toka";
        }


        [Route("pvm")]
        public DateTime Päivämäärä()
        {
            return DateTime.Now;
        }

        [Route("numerot")]
        public List<int> PalautaNumeroLista()
        {
            List<int> numerot = new List<int>() { 1, 2, 3, 4, 5 };              ///ASP.NET osaa muuttaa listan JSON:ksi suoraan.
            return numerot;
        }




        //public string GetCustomers(string id)
        //{
        //    NorthwindContext konteksti = new NorthwindContext();
        //    List<Customers> asiakkaat;

        //    if (string.IsNullOrEmpty(id))
        //    {
        //        asiakkaat = konteksti.Customers.ToList();               // jos id on tyhjä hakee kaikki Customerit listaksi
        //    }
        //    else
        //    {
        //        string maa = id;
        //        asiakkaat = (from a in konteksti.Customers              // jos id ei ole tyhjä, haetaan asiakkaat joiden id täsmää.
        //                     where a.Country == maa
        //                     select a).ToList();
        //    };

        //    string tiedot;

        //    foreach (var asiakas in asiakkaat) {

        //    }

        //    return ($"asiakkaan maa on:{asiakkaat[0].Country.ToString()}");
        //}


    }
}