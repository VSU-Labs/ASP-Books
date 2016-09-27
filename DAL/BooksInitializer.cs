using System;
using System.Collections.Generic;
using System.Data.Entity;
using Books.Models;

namespace Books.DAL
{
	public class BooksInitializer : DropCreateDatabaseAlways<BooksContext>
	{
		protected override void Seed(BooksContext context) 
		{
			List<Author> authors = new List<Author> {
				new Author("Толстой", new DateTime(1920, 1, 1)),
				new Author("Тургеньев", new DateTime(1930, 1, 1))
			};

			List<Book> books = new List<Book> {
				new Book("Война и мир", new DateTime(1900, 1, 1)),
				new Book("Отцы и дети", new DateTime(1950, 1, 1))
			};

			authors[0].Books.Add(books[0]);
			authors[1].Books.Add(books[1]);

			authors.ForEach (author => context.Authors.Add (author));
			books.ForEach (book => context.Books.Add (book));
			context.SaveChanges ();
		}
	}
}

