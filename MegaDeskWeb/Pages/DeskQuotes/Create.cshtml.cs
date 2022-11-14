using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public CreateModel(MegaDeskWebContext context)
        {
            _context = context;
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; } = default!;
        [BindProperty]
        public Desk Desk { get; set; } = default;

        public SelectList ? Material { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ? SearchMaterials { get; set; }




        public IActionResult OnGet()
        {

        ViewData["DeskId"] = new SelectList(_context.Desk, "DeskId", "DeskId");
        ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "name");
            return Page();

        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.DeskQuote == null || DeskQuote == null)
            {
                return Page();
            }

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
