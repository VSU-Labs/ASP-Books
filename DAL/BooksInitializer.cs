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
				new Author("Толстой, Лев Николаевич", new DateTime(1828, 09, 09)),
				new Author("Пушкин, Александр Сергеевич", new DateTime(1799, 06, 06)),
				new Author("Тургенев, Иван Сергеевич", new DateTime(1818, 11, 09)),
				new Author("Ильф, Илья Арнольдович", new DateTime(1897, 10, 15)),
				new Author("Петров, Евгений Петрович", new DateTime(1902, 12, 13)),
				new Author("Стругацкий, Аркадий Натанович", new DateTime(1925, 08, 28)),
				new Author("Стругацкий, Борис Натанович", new DateTime(1933, 04, 15))
			};

			List<Book> books = new List<Book> {
				new Book("Война и мир", new DateTime(1869, 1, 1)),
				new Book("Отцы и дети", new DateTime(1862, 2, 1))
			};

			authors[0].Books.Add(books[0]);
			authors[1].Books.Add(books[1]);

			authors.ForEach (author => context.Authors.Add (author));
			books.ForEach (book => context.Books.Add (book));
			context.SaveChanges ();
		}
	}
}

