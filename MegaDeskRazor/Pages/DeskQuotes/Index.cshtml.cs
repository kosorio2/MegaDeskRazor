using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskRazor.Data;
using MegaDeskRazor.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MegaDeskRazor.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskRazor.Data.MegaDeskRazorContext _context;

        public IndexModel(MegaDeskRazor.Data.MegaDeskRazorContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList CustomerNames { get; set; }
       
        //[BindProperty(SupportsGet = true)]
        //public string DQCustomer { get; set; }

        public async Task OnGetAsync()
        {
            // Use LINQ to get list of genres.
            //IQueryable<string> dqQuery = from dq in _context.DeskQuote
            //                                orderby dq.CustomerName
            //                                select dq.CustomerName;

            var dqs = from dq in _context.DeskQuote
                         select dq;

            if (!string.IsNullOrEmpty(SearchString))
            {
                dqs = dqs.Where(s => s.CustomerName.Contains(SearchString));
            }

            //if (!string.IsNullOrEmpty(DQCustomer))
            //{
            //    dqs = dqs.Where(x => x.CustomerName == DQCustomer);
            //}
            //CustomerNames = new SelectList(await dqQuery
            //    .Include(d => d.Desk)
            //    .Include(s => s.
            //    .Distinct().ToListAsync());
            
            DeskQuote = await dqs
                .Include(d => d.Desk)
                .Include(d => d.DeliveryType)
                .Include(d => d.Desk.SurfaceMaterial)
                .ToListAsync();
        }
    }
}
