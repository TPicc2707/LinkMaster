using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkMasters.Data
{
    public class LinkMastersContext : DbContext
    {
        public LinkMastersContext(DbContextOptions<LinkMastersContext> options)
            : base(options)
        {
        }

        public DbSet<LinkMasters.Models.Link> Link { get; set; }

        public DbSet<LinkMasters.Models.Application> Application { get; set; }

        public DbSet<LinkMasters.Models.Image> Image { get; set; }

        public DbSet<LinkMasters.Models.Calendar> Calendar { get; set; }
        public DbSet<LinkMasters.Models.Day> Day { get; set; }
        public DbSet<LinkMasters.Models.Person> Person { get; set; }

        public DbSet<LinkMasters.Models.Allowance> Allowance { get; set; }

        public DbSet<LinkMasters.Models.Budget> Budget { get; set; }

        public DbSet<LinkMasters.Models.YearBudget> YearBudget { get; set; }

        public DbSet<LinkMasters.Models.MuscleGroup> MuscleGroup { get; set; }

        public DbSet<LinkMasters.Models.SpongebobCharacter> SpongebobCharacter { get; set; }

        public DbSet<LinkMasters.Models.SpongebobMeme> SpongebobMeme { get; set; }

        public DbSet<LinkMasters.Models.SpongebobQuotes> SpongebobQuotes { get; set; }
    }
}
