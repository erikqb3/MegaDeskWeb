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

        [BindProperty (SupportsGet = true)] public DeskQuote DeskQuote { get; set; } = default!;
        [BindProperty (SupportsGet = true)] public Desk Desk { get; set; } = default;
        [BindProperty (SupportsGet = true)] public RushOption RushOption { get; set; } = default;
        [BindProperty (SupportsGet = true)] public Material MaterialsDB { get; set; } = default;

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
            _context.Material.Add(MaterialsDB);
            await _context.SaveChangesAsync();

            Console.WriteLine(_context.RushOption);

            // _context.DeskQuote.Add(RushOption);
            // await _context.SaveChangesAsync();

            // set desk Id
            DeskQuote.DeskId = Desk.DeskId;
            // Console.Write(DeskQuote);
            // set desk
            DeskQuote.Desk = Desk;
            DeskQuote.Desk.Material = MaterialsDB;
            // DeskQuote.RushOption = RushOption;
          
            // _context.DeskQuote.Add(RushOptionsDB);

            var rushDaysQuery = from option in _context.RushOption
                                    where option.RushOptionId == DeskQuote.RushOptionId
                                    select option.days;
            var materialQuery = from option in _context.Material
                                    where option.MaterialId == DeskQuote.Desk.MaterialId
                                    select option.price;

            int rushDaysValue = rushDaysQuery.FirstOrDefault();
            int materialCost = materialQuery.FirstOrDefault();
            // Material materialValue = materialQuery.FirstOrDefault();

            // var rushDays = from rO in _context.RushOption
            //                 select rO;
            
            // rushDays = rushDays.Where(rD => rD.days == DeskQuote.RushOptionId);

            // var RushOptionVariable = SelectedRushOption;

            Console.WriteLine("START");
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine(materialCost);
            // MaterialsDB.getMaterialCost(materialCost);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("END");
            // var rushOption = await _context.RushOption
            //                     .Include( rO => rO.days)
            //                     .Include(rO => rO.Desk)
            //                     .FirstOrDefaultAsync(m => m.RushOptionId == id);


            // IQueryable<RushOption>SelectedRushOption 
            //set setquote date
            // DeskQuote.startDate = DateTime.Now;

            
            // DeskQuote.finishDate = DateTime.Now;
            // DeskQuote.finishDate = DateTime.Now.AddDays(Convert.ToDouble(rushDays)); 
            DeskQuote.finishDate = DateTime.Now.AddDays(Convert.ToDouble(rushDaysValue)); 
            DeskQuote.quoteTotalPrice = DeskQuote.quoteTotalPrice + Desk.getAreaCost(Desk.depth,Desk.width) + Desk.getDrawerCost(Desk.drawerCount);
            




            // DeskQuote.finishDate = DateTime.Now.AddDays(Convert.ToDouble(Desk.RushOption)); 
            // DeskQuote.quoteTotalPrice = DeskQuote.quoteTotalPrice + Desk.getExtraCost(Desk.depth,Desk.width);

            _context.DeskQuote.Add(DeskQuote);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
