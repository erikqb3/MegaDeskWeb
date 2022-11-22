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
        [BindProperty] public RushOption RushOption { get; set; } = default;
        [BindProperty] public RushOption MaterialsDB { get; set; } = default;

        // [BindProperty] public DeskQuote RushOption { get; set; } = default!;


        public SelectList ? Material { get; set; } = default;
        [BindProperty(SupportsGet = true)] public string ? SearchMaterials { get; set; }
        public SelectList ? RushOptionSelect { get; set; } = default;
        [BindProperty(SupportsGet = true)] public string ? SelectRush { get; set; }




        public IActionResult OnGet()
        {

        // ViewData["DeskId"] = new SelectList(_context.Desk, "DeskId", "DeskId");
        
        // ViewData["starDate"] = new SelectList(_context.DeskQuote, "DeskQuoteId", "startDate");
        ViewData["MaterialId"] = new SelectList(_context.Material, "MaterialId", "name");
        ViewData["RushOptionId"] = new SelectList(_context.RushOption, "RushOptionId", "days");
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

            Console.WriteLine(_context.RushOption);

            // _context.DeskQuote.Add(RushOption);
            // await _context.SaveChangesAsync();

            // set desk Id
            DeskQuote.DeskId = Desk.DeskId;
            // Console.Write(DeskQuote);
            // set desk
            DeskQuote.Desk = Desk;
            // DeskQuote.RushOption = RushOption;
          
            // _context.DeskQuote.Add(RushOptionsDB);

            var SelectedRushOption = from pikachu in _context.RushOption
                                                        where pikachu.RushOptionId == DeskQuote.RushOptionId
                                                        select pikachu.days;

            // var RushOptionVariable = SelectedRushOption;

            Console.WriteLine(SelectedRushOption);
            // var rushOption = await _context.RushOption
            //                     .Include( rO => rO.days)
            //                     .Include(rO => rO.Desk)
            //                     .FirstOrDefaultAsync(m => m.RushOptionId == id);


            // IQueryable<RushOption>SelectedRushOption 
            //set setquote date
            // DeskQuote.startDate = DateTime.Now;


            // DeskQuote.finishDate = DateTime.Now;
            DeskQuote.finishDate = DateTime.Now.AddDays(Convert.ToDouble(SelectedRushOption)); 
            DeskQuote.quoteTotalPrice = DeskQuote.quoteTotalPrice + Desk.getExtraCost(Desk.depth,Desk.width);




            // DeskQuote.finishDate = DateTime.Now.AddDays(Convert.ToDouble(Desk.RushOption)); 
            // DeskQuote.quoteTotalPrice = DeskQuote.quoteTotalPrice + Desk.getExtraCost(Desk.depth,Desk.width);

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
