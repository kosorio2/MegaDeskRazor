using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class CreateModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context; //This pulling from the database

        public CreateModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["DeliveryId"] = new SelectList(_context.Set<Delivery>(), "DeliveryId", "DeliveryType");
        ViewData["DesktopMaterialId"] = new SelectList(_context.Set<DesktopMaterial>(), "DesktopMaterialId", "DesktopMaterialName");
            //The selectList is wrapping the values with option tags in HTML
            return Page();
        }

        [BindProperty]
        public DeskQuote DeskQuote { get; set; } //This creates a deskquote object, takes all the values and assigns them to the properties

        [BindProperty]
        public Desk Desk{ get; set; } // This creates a desk 


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) //If any of the models are not correct, this will just return the page
            {
                return Page();
            }


            //This will add Desk to database
            _context.Desk.Add(Desk); //Thanks to this, Desk will now have an ID
            await _context.SaveChangesAsync();


            //Add Deskquote properties
            DeskQuote.QuoteDate = DateTime.Now; // This will gerenare automatically
            DeskQuote.DeskId = Desk.DeskId;
            DeskQuote.Desk = Desk;
            DeskQuote.QuotePrice = DeskQuote.GetQuotePrice(_context);



            //If everything is fine, then this will run 
            _context.DeskQuote.Add(DeskQuote);

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
