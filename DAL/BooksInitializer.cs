using System;
using System.Data.Entity;
using Books.Models;

namespace Books.DAL
{
	public class BooksInitializer : DropCreateDatabaseAlways<BooksContext>
	{
		protected override void Seed(BooksContext context) 
		{
			Author Tolstoy = new Author { AuthorId = 1, Name = "Толстой", Birthday = new DateTime(1920, 1, 1)};
			context.Authors.Add (Tolstoy);
			Author Turgenyev = new Author { AuthorId = 2, Name = "Тургеньев", Birthday = new DateTime(1930, 1, 1)};
			context.Authors.Add (Turgenyev);
			context.Books.Add (new Book { BookId = 1, Name = "Война и мир", PublishDate = new DateTime(1900, 1, 1) });
			context.Books.Add (new Book { BookId = 2, Name = "Отцы и дети", PublishDate = new DateTime(1950, 1, 1) });
			context.SaveChanges ();
		}
	}
}

