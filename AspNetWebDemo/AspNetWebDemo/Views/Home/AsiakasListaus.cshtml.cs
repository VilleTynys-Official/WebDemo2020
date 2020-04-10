using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AspNetWebDemo.Tietokanta;

namespace AspNetWebDemo.Views.Home
{
    public class AsiakasListausModel : PageModel
    {
        private readonly AspNetWebDemo.Tietokanta.NorthwindContext _context;

        public AsiakasListausModel(AspNetWebDemo.Tietokanta.NorthwindContext context)
        {
            _context = context;
        }

        public IList<Customers> Customers { get;set; }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.ToListAsync();
        }
    }
}
