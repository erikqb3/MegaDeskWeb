using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_Desks
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public IndexModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        public IList<Desk> Desk { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Desk != null)
            {
                Desk = await _context.Desk
                .Include(d => d.Material)
                .Include(d => d.RushOption).ToListAsync();
            }
        }
    }
}
