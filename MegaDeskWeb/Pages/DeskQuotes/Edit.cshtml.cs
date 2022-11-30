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
        public Desk Desk { get; set; } = default;

        public async Task<IActionResult> OnGetAsync(int? id)
        {

            ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "name");
            ViewData["RushOptionId"] = new SelectList(_context.RushOption, "RushOptionId", "days");
            
            if (id == null || _context.DeskQuote == null)
            {
                return NotFound();
            }

            var deskquote = await _context.DeskQuote
                .Include(m => m.Desk)
                    .ThenInclude(m => m.Material)
                        .FirstOrDefaultAsync(m => m.DeskQuoteId == id);

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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }



            // DeskQuote.DeskId = Desk.DeskId;
            // DeskQuote.Desk = Desk;


            var rushQuery = from option in _context.RushOption
                                where option.RushOptionId == DeskQuote.RushOptionId
                                select option;

            RushOption rushObject = rushQuery.FirstOrDefault();


            Console.WriteLine(rushObject.days);
            // Console.WriteLine(DeskQuote.RushOption.days);
            Console.WriteLine();
            Console.WriteLine();





            DeskQuote.finishDate = DateTime.Now.AddDays(Convert.ToDouble(rushObject.days));

            DeskQuote.quoteTotalPrice = 
                DeskQuote.quoteTotalPrice +
                DeskQuote.Desk.getAreaCost(DeskQuote.Desk.depth,DeskQuote.Desk.width) +
                DeskQuote.Desk.getDrawerCost(DeskQuote.Desk.drawerCount);
                // + 
                // Desk.getAreaCost(DeskQuote.Desk.depth,DeskQuote.Desk.width);
            
            // DeskQuote.quoteTotalPrice = 
            //     DeskQuote.quoteTotalPrice +
            //     Desk.getAreaCost(Desk.depth,Desk.width) + 
            //     Desk.getDrawerCost(Desk.drawe rCount);
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
