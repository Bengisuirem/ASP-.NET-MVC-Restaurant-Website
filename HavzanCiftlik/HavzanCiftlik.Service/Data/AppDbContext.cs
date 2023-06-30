using HavzanCiftlik.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace HavzanCiftlik.Service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Menu> Menu { get; set; }       

		public DbSet<Kasa> Kasa { get; set; }

		public DbSet<human> human { get; set; }

	}
}
