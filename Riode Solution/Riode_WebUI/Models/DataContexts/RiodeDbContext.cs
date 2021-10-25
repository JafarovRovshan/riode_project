using Microsoft.EntityFrameworkCore;
using Riode_WebUI.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Riode_WebUI.Models.DataContexts
{
    public class RiodeDbContext : DbContext
    {
        public RiodeDbContext()
            : base()
        {

        }

        public RiodeDbContext(DbContextOptions options)
         : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=RiodeWithGit;User Id=sa;Password=query;");
            }
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<ProductColor> Colors { get; set; }


    }
}
