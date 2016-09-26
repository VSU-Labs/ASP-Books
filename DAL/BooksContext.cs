using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Books.Models;

namespace Books.DAL
{
	[DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
	public class BooksContext : DbContext
	{
		public BooksContext () : base("BooksContext")
		{
		}
		static BooksContext ()
		{
			DbConfiguration.SetConfiguration(new MySql.Data.Entity.MySqlEFConfiguration());
		}

		public DbSet<Book> Books { get; set; }
		public DbSet<Author> Authors { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
			base.OnModelCreating(modelBuilder);
		}
	}
}

