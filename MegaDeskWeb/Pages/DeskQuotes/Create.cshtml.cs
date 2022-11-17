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

        [BindProperty] public DeskQuote DeskQuote { get; set; } = default!;
        [BindProperty] public Desk Desk { get; set; } = default;

        public SelectList ? Material { get; set; }
        [BindProperty(SupportsGet = true)] public string ? SearchMaterials { get; set; }
        public SelectList ? RushOption { get; set; }
        [BindProperty(SupportsGet = true)] public string ? SelectRush { get; set; }




        public IActionResult OnGet()
        {

        // ViewData["DeskId"] = new SelectList(_context.Desk, "DeskId", "DeskId");
        
        // ViewData["starDate"] = new SelectList(_context.DeskQuote, "DeskQuoteId", "startDate");
        ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "name");
        ViewData["RushOptionId"] = new SelectList(_context.RushOption, "RushOptionId", "days");
        // Console.WriteLine("HELLOW HONEST");
        // Console.WriteLine();
        // Console.WriteLine();
        // Console.WriteLine(_context.Material);
        // Console.WriteLine();
        // Console.WriteLine();
        // Console.WriteLine("Hellow Charity");
            return Page();

        }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                Console.WriteLine("invalid page");
                return Page();
            }
            // SAVE DESK FIRST AND ASSIGN TO 

            //add desk
            _context.Desk.Add(Desk);
            await _context.SaveChangesAsync();

            // set desk Id
            DeskQuote.DeskId = Desk.DeskId;
            // Console.Write(DeskQuote);
            // set desk
            DeskQuote.Desk = Desk;

            //set setquote date
            DeskQuote.startDate = DateTime.Now;
            DeskQuote.finishDate = DateTime.Now;
            DeskQuote.quoteTotalPrice = Desk.getExtraCost(Desk.depth,Desk.width);

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
