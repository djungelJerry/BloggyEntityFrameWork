using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BloggyEntityFrameWork
{


	
	internal class MyDbContext : DbContext
	{

		public DbSet<BlogPost> blogs { get; set; }
		public DbSet<Category> categories { get; set; }


		string name = "windowsConnection";
		string ConnectionString = "Server=localhost; Database=BEF3; Trusted_Connection=True; TrustServerCertificate=True;";


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{ optionsBuilder.UseSqlServer(ConnectionString); }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
		}
	}
}
