using CoreWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreWebApi.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
           
        }
         public DbSet<NationalPark> nationalParks { get; set; }
         public DbSet<Trail> Trails { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
