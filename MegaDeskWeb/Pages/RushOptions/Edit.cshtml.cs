using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_RushOptions
{
    public class EditModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public EditModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public RushOption RushOption { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.RushOption == null)
            {
                return NotFound();
            }

            var rushoption =  await _context.RushOption.FirstOrDefaultAsync(m => m.RushOptionId == id);
            if (rushoption == null)
            {
                return NotFound();
            }
            RushOption = rushoption;
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

            _context.Attach(RushOption).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RushOptionExists(RushOption.RushOptionId))
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

        private bool RushOptionExists(int id)
        {
          return (_context.RushOption?.Any(e => e.RushOptionId == id)).GetValueOrDefault();
        }
    }
}
