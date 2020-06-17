using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MOHEswatini.Models
{
    public class DbMOHEswatini : DbContext
    {
        public DbSet<mLogin> MLogins { get; set; }
        public DbSet<mDiseaseSurveillance> mDiseaseSurveillances { get; set; }
        public DbMOHEswatini(DbContextOptions<DbMOHEswatini> options): base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(Configuration.GetConnectionString("ArnikaInfotechDBConnection")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
