using System;
using System.Collections.Generic;

namespace Books.Models
{
	public class Author
	{
		public Author() {
		}

		public Author(String name, DateTime birthday) {
			AuthorId = maxId++;
			Name = name;
			Birthday = birthday;
			Books = new List<Book>();
		}

		private static int maxId = 1;
		public int AuthorId { get; set; }
		public String Name { get; set; }		
		public DateTime Birthday { get; set; }

		public virtual ICollection<Book> Books { get; set; }
	}
}

