using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

namespace MegaDeskWeb.Pages_Materials
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWebContext _context;

        public DetailsModel(MegaDeskWebContext context)
        {
            _context = context;
        }

      public Material Material { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Material == null)
            {
                return NotFound();
            }

            var material = await _context.Material.FirstOrDefaultAsync(m => m.MaterialId == id);
            if (material == null)
            {
                return NotFound();
            }
            else 
            {
                Material = material;
            }
            return Page();
        }
    }
}
