using System;
using System.Collections.Generic;

namespace Books.Models
{
	public class Book
	{
		public Book() {
		}

		public Book(String name, DateTime publishDate) {
			BookId = maxId++;
			Name = name;
			PublishDate = publishDate;
			Authors = new List<Author> ();
		}

		private int maxId = 1;
		public int BookId { get; set; }
		public String Name { get; set; }
		public DateTime PublishDate { get; set; }

		public virtual ICollection<Author> Authors { get; set; }
	}
}

