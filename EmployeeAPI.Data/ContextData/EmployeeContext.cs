using EmployeeAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeAPI.Data.ContextData
{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions<EmployeeContext> options)
         : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) =>
            // Configure a trigger for your table (replace "SomeTrigger" with your actual trigger name)
            modelBuilder.Entity<EmpData>()
                .ToTable(tb => tb.HasTrigger("trggaddemployeecode"));

        public DbSet<EmpData> Employee { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }


    }
}
