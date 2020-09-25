using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace singToSeminar.Context
{
    public class ApplikationDbContext : DbContext
    {
        public DbSet<Booking> Bookings { set; get; }
        public DbSet<Seminar> Seminars { set; get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-PIBHJHK\SQLEXPRESS;Database=singToSeminar;Trusted_Connection=True;");
        }
    }
}
