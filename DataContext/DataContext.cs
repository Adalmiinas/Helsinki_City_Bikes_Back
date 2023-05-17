using System;
using Microsoft.EntityFrameworkCore;
using HelsinkiBikes.Model;

namespace HelsinkiBikes.DataContext
{
    public class DataContexts : DbContext
    {

        public DbSet<Trip> Trips { get; set; }
        public DbSet<Station> Stations { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=HelsinkiBikes; User id=SA; Password=Password123; Integrated Security=false;");
        }


    }

}

