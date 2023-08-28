using IDGS903_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace IDGS903_Api.Context
{
	public class AppDbContext2 : DbContext
	{
		public AppDbContext2(DbContextOptions<AppDbContext2> options) : base(options) { }

		public DbSet<TablaTotalVentas> TablaTotalVentas { get; set; }
		public DbSet<TablaTotalUsuarios> TablaTotalUsuarios { get; set; }
		public DbSet<TablaTotalProductos> TablaTotalProductos { get; set; }
		public DbSet<TablaTotalPedidos> TablaTotalPedidos { get; set; }
		public DbSet<TablaTotalMateriaPrima> TablaTotalMateriaPrima { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<TablaTotalVentas>().HasNoKey();
		}
	}
}
