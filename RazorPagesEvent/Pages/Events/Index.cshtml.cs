using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesEvent.Data;
using RazorPagesEvent.Models;

namespace RazorPagesEvent.Pages.Events
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesEvent.Data.RazorPagesEventContext _context;

        public IndexModel(RazorPagesEvent.Data.RazorPagesEventContext context)
        {
            _context = context;
        }



        //public IList<Event> Event { get; set; }
        //search öncesi
        //public async Task OnGetAsync()
        //{
        //    Event = await _context.Event.ToListAsync();
        //}

        public IList<Event> Event { get; set; }

        [BindProperty(SupportsGet = true)] //bunu urı'dan alacak 
        public string SearchString { get; set; }

        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        public SelectList Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string EventGenre
        {
            get; set;
        }

        //search için
        public async Task OnGetAsync()
        {
            var events = from m in _context.Event 
                         select m;

            // Use LINQ to get list of genres. (Tür listesi)
            IQueryable<string> genreQuery = from m in _context.Event
                                            orderby m.Genre
                                            select m.Genre;
            //First filter by EventName
            if (!string.IsNullOrEmpty(SearchString))
            {
                events = events.Where(s => s.EventName.Contains(SearchString));
            }
            //Then, Filter by EventGenre
            if (!string.IsNullOrEmpty(EventGenre))
            {
                events = events.Where(x => x.Genre==EventGenre);
            }
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Event = await events.ToListAsync(); //set items to eventlist 
            
        }

       
    }
}
