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
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public DetailsModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty] public DeskQuote DeskQuote { get; set; } = default!;
        [BindProperty] public Desk Desk { get; set; } = default;
        [BindProperty] public Material Material { get; set; } = default;


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeskQuote == null)
            {
                return NotFound();
            }

            var deskquote = await _context.DeskQuote
                .Include(m => m.Desk)
                    .ThenInclude(m => m.Material)
                        .FirstOrDefaultAsync(m => m.DeskQuoteId == id);
            // var desk = await _context.Desk.FirstOrDefaultAsync(n => n.DeskId == id);
            // var material = await _context.Material.FirstOrDefaultAsync(o => o.MaterialId == id);

            if (deskquote == null)
            {
                return NotFound();
            }
            else 
            {
                DeskQuote = deskquote;
            }
            return Page();
        }

    }
}
