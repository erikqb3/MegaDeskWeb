using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_ExtraPages_RushOptions
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public CreateModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public RushOption RushOption { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.RushOption == null || RushOption == null)
            {
                return Page();
            }

            _context.RushOption.Add(RushOption);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
