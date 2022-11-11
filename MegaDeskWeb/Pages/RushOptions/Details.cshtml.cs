using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_RushOptions
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public DetailsModel(MegaDeskWebContext context)
        {
            _context = context;
        }

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
    }
}
