using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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

		[DisplayName("ФИО")]
		public String Name { get; set; }

		[DisplayName("День рождения")]
		[DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
		public DateTime Birthday { get; set; }

		public virtual ICollection<Book> Books { get; set; }
	}
}

