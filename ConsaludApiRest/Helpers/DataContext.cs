using System;
using Consalud.Model.Entities;
using Microsoft.EntityFrameworkCore;

namespace ConsaludApiRest.Helpers
{
	public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            string dbPath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "TestDb.db");
            // in memory database used for simplicity, change to a real db for production applications
            options.UseSqlite($"Data Source={dbPath}");
        }

        public DbSet<User> Users { get; set; }
    }
}

