using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesEvent.Models;

namespace RazorPagesEvent.Data
{
    public class RazorPagesEventContext : DbContext
    {
        public RazorPagesEventContext (DbContextOptions<RazorPagesEventContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesEvent.Models.Event> Event { get; set; }
    }
}
