using System;
using Consalud.Model.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Consalud.DataAccess
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
            // in memory database used for simplicity, change to a real db for production applications
            options.UseSqlite("Data Source=desafio_db.db");
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Factura> Facturas { get; set; }
    }
}

