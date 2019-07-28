using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularApi.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        { }
        public DbSet<TestQuestion> Questions { get; set; }
        public DbSet<Quez> Quezes { get; set; }
        public DbSet<EqupmentName> equpmentNames { get; set; }
        public DbSet<Equpment> equpments { get; set; }
        public DbSet<Locatio> locations { get; set; }
        public DbSet<Room> rooms { get; set; }
        public DbSet<Set> sets { get; set; }


    }
}
