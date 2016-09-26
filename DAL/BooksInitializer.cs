using System;
using System.Data.Entity;
using Books.Models;

namespace Books.DAL
{
	public class BooksInitializer : DropCreateDatabaseAlways<BooksContext>
	{
		protected override void Seed(BooksContext context) 
		{
			context.Books.Add (new Book { BookId = 1, Name = "Война и мир", PublishDate = new DateTime(1900, 1, 1) });
			context.Books.Add (new Book { BookId = 2, Name = "Отцы и дети", PublishDate = new DateTime(1950, 1, 1) });
			context.SaveChanges ();
		}
	}
}

