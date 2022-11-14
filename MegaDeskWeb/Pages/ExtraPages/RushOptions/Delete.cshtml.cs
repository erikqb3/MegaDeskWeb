using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_ExtraPages_RushOptions
{
    public class DeleteModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public DeleteModel(MegaDeskWebContext context)
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

            var rushoption = await _context.RushOption.FirstOrDefaultAsync(m => m.RushOptionId == id);

            if (rushoption == null)
            {
                return NotFound();
            }
            else 
            {
                RushOption = rushoption;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.RushOption == null)
            {
                return NotFound();
            }
            var rushoption = await _context.RushOption.FindAsync(id);

            if (rushoption != null)
            {
                RushOption = rushoption;
                _context.RushOption.Remove(RushOption);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
