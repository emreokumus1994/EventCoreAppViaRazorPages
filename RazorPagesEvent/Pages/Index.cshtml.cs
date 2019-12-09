using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RazorPagesEvent.Models;

namespace RazorPagesEvent.Pages
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesEvent.Data.RazorPagesEventContext _context;

        public IndexModel(RazorPagesEvent.Data.RazorPagesEventContext context)
        {
            _context = context;
        }

        public IList<Event> Event { get; set; }
        public async Task OnGetAsync()
        {
            var events = from m in _context.Event
                         select m;
     
            events = events.Where(s => s.EventDate>=(DateTime.Now.Date));

            Event = await events.ToListAsync(); //set items to eventlist 
        }
    }
}
