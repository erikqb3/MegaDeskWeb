using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb.Models;

    public class MegaDeskWebContext : DbContext
    {
        public MegaDeskWebContext (DbContextOptions<MegaDeskWebContext> options)
            : base(options)
        {
        }

        public DbSet<MegaDeskWeb.Models.Desk> Desk { get; set; } = default!;

        public DbSet<MegaDeskWeb.Models.DeskQuote>? DeskQuote { get; set; }

        public DbSet<MegaDeskWeb.Models.Material>? Material { get; set; }

        public DbSet<MegaDeskWeb.Models.RushOption>? RushOption { get; set; }
    }
