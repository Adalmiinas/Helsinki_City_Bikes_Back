using System;
using Microsoft.EntityFrameworkCore;
using HelsinkiBikes.Model;

namespace HelsinkiBikes.DataContext
{
    public class DataContexts : DbContext
    {
        public string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["helsinkiBikes"].ConnectionString;
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Station> Stations { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

}

