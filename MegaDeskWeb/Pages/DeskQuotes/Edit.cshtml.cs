using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_DeskQuotes
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public EditModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty]public DeskQuote DeskQuote { get; set; } = default!;
        [BindProperty]public Desk Desk { get; set; } = default;
        [BindProperty] public Material Material { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DeskQuote == null)
            {
                return NotFound();
            }

            var deskquote =  await _context.DeskQuote.FirstOrDefaultAsync(m => m.DeskQuoteId == id);
            var desk = await _context.Desk.FirstOrDefaultAsync(n => n.DeskId == id);
            var material = await _context.Material.FirstOrDefaultAsync(o => o.MaterialId == id);

            if (deskquote == null || desk == null || material == null)
            {
                return NotFound();
            }
            else 
            {
                DeskQuote = deskquote;
                Desk = desk;
                Material = material;
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DeskQuote).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskQuoteExists(DeskQuote.DeskQuoteId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DeskQuoteExists(int id)
        {
          return (_context.DeskQuote?.Any(e => e.DeskQuoteId == id)).GetValueOrDefault();
        }
    }
}
