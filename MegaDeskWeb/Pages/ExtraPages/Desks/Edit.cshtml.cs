using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_Desks
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public EditModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Desk Desk { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Desk == null)
            {
                return NotFound();
            }

            var desk =  await _context.Desk.FirstOrDefaultAsync(m => m.DeskId == id);
            if (desk == null)
            {
                return NotFound();
            }
            Desk = desk;
           ViewData["MaterialId"] = new SelectList(_context.Set<Material>(), "MaterialId", "MaterialId");
           ViewData["RushOptionId"] = new SelectList(_context.Set<RushOption>(), "RushOptionId", "RushOptionId");
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

            _context.Attach(Desk).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskExists(Desk.DeskId))
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

        private bool DeskExists(int id)
        {
          return (_context.Desk?.Any(e => e.DeskId == id)).GetValueOrDefault();
        }
    }
}