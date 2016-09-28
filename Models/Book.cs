using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
	public class Book
	{
		public Book() {
		}

		public Book(String title, DateTime publishDate) {
			BookId = maxId++;
			Title = title;
			PublishDate = publishDate;
			Authors = new List<Author> ();
		}

		private int maxId = 1;
		public int BookId { get; set; }

		[DisplayName("Название")]
		public String Title { get; set; }


		[DisplayName("Дата публикации")]
		[DisplayFormat(DataFormatString = "{0:MMMM yyyy}")]
		public DateTime PublishDate { get; set; }

		public virtual ICollection<Author> Authors { get; set; }
	}
}

