using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using BlazorWebAppAPI.Models;

namespace BlazorWebAppAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }//For each table I have, this line of code is needed for them
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Customize Data Model

            //Define as nvarchar
            modelBuilder.Entity<Employee>().Property("EmployeeName").IsUnicode(false);

            base.OnModelCreating(modelBuilder); 
        }
    }
}
