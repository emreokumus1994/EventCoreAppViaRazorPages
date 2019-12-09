using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPagesEvent.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesEvent.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new RazorPagesEventContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<RazorPagesEventContext>>()))
            {
                // Look for any Events.
                if (context.Event.Any())
                {
                    return;   // DB has been seeded
                }

                context.Event.AddRange(
                    new Event
                    {
                        EventName = "Generic Music Day of Death",
                        EventDate  = DateTime.Parse("2019-10-12"),
                        Genre = "Deep House",
                        Price = 7.99M,
                        Rating="B",
                        Country="Turkey"
                    },

                    new Event
                    {
                        EventName = "Mix Festival ",
                        EventDate = DateTime.Parse("2019-11-13"),
                        Genre = "Deep House",
                        Price = 8.99M,
                        Rating="B",
                        Country = "Turkey"

                    },

                    new Event
                    {
                        EventName = "BigBurn",
                        EventDate = DateTime.Parse("1986-2-23"),
                        Genre = "Techno",
                        Price = 9.99M,
                        Rating="A",
                        Country = "Turkey"

                    },

                    new Event
                    {
                        EventName = "Coldplay",
                        EventDate = DateTime.Parse("2020-8-15"),
                        Genre = "Alternative Rock",
                        Price = 3.99M,
                        Rating="A",
                        Country = "Turkey"
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
