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
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public DeleteModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty] public DeskQuote DeskQuote { get; set; } = default!;
        [BindProperty] public Desk Desk { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeskQuote == null)
            {
                return NotFound();
            }

            var deskquote = await _context.DeskQuote.FirstOrDefaultAsync(m => m.DeskQuoteId == id);
            var desk = await _context.Desk.FirstOrDefaultAsync(n => n.DeskId == id);

            if (deskquote == null || desk == null)
            {
                return NotFound();
            }
            else 
            {
                DeskQuote = deskquote;
                Desk = desk;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DeskQuote == null)
            {
                return NotFound();
            }
            var deskquote = await _context.DeskQuote.FindAsync(id); 

            if (deskquote != null)
            {
                DeskQuote = deskquote;
                _context.DeskQuote.Remove(DeskQuote);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
