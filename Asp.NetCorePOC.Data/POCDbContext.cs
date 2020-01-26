using Asp.NetCorePOC.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asp.NetCorePOC.Data
{
    public class POCDbContext : DbContext
    {
        public POCDbContext(DbContextOptions<POCDbContext> options)
            : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
