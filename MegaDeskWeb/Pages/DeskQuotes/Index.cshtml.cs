using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public IndexModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.DeskQuote != null)
            {
                DeskQuote = await _context.DeskQuote
                .Include(d => d.Desk).ToListAsync();
            }
        }
    }
}
