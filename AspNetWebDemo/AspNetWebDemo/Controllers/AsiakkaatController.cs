using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AspNetWebDemo.Tietokanta;

namespace AspNetWebDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsiakkaatController : ControllerBase
    {

        [HttpPost]       //määrittää REST verbin POST.
        [Route("")]     //halutaan pitää route samana.
        public bool LisääAsiakas(Customers asiakas)     //Create toiminto (otetaan parametri sisälle). ASP.NET hoitaa JSON muunnokset.
        {
            NorthwindContext konteksti = new NorthwindContext();
            konteksti.Customers.Add(asiakas);
            konteksti.SaveChanges();
            return true;
        }

        [HttpGet]
        [Route("")]
        public List<Customers> HaeKaikki()
        {
            NorthwindContext konteksti = new NorthwindContext();        //haetaan konteksti ja ladataan listalle asiakkaat.
            List<Customers> asiakkaat = konteksti.Customers.ToList();
            return asiakkaat;
        }



        //[HttpPut]       //määrittää REST verbin PUT (eli tietojen päivittäminen).
        //[Route("")]     //halutaan pitää route samana.
        //public bool PäivitäAsiakasTietoja(Customers asiakas)     //Create toiminto (otetaan parametri sisälle). ASP.NET hoitaa JSON muunnokset.
        //{
        //    NorthwindContext konteksti = new NorthwindContext();
        //    konteksti.Customers.Mo(asiakas);
        //    konteksti.SaveChanges();
        //    return true;
        //}








    }
}