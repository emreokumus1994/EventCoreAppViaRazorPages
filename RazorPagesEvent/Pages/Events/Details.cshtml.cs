using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesEvent.Data;
using RazorPagesEvent.Models;

namespace RazorPagesEvent.Pages.Events
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesEvent.Data.RazorPagesEventContext _context;

        public DetailsModel(RazorPagesEvent.Data.RazorPagesEventContext context)
        {
            _context = context;
        }

        public Event Event { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Event = await _context.Event.FirstOrDefaultAsync(m => m.ID == id);

            if (Event == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
