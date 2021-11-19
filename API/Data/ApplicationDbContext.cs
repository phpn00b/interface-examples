using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using DependencyInjectionExample.Model;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext([NotNull] DbContextOptions options)
			: base(options) { }
		public DbSet<Client> Clients { get; set; }
		public DbSet<PhoneNumber> PhoneNumbers { get; set; }

		public DbSet<Address> Addresses { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder options)
			=> options.UseSqlite("Data Source=data.db");
	}
}
