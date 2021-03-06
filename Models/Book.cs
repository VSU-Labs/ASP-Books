﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Books.Models
{
	public class Book
	{
		public Book() {
			Authors = new List<Author> ();
		}

		public Book(String title, DateTime publishDate) {
			BookId = maxId++;
			Title = title;
			PublishDate = publishDate;
			Authors = new List<Author> ();
		}

		public void Clone(Book book) {
			BookId = book.BookId;
			Title = book.Title;
			PublishDate = book.PublishDate;
			Authors.Clear ();
			if (book.Authors == null)
				return;

			foreach (Author author in book.Authors) {
				Authors.Add (author);
			}
		}

		private int maxId = 1;
		public int BookId { get; set; }

		[DisplayName("Название")]
		[Required(ErrorMessage = "У книги должно быть название")]
		public String Title { get; set; }


		[DisplayName("Дата публикации")]
		[DisplayFormat(DataFormatString = "{0:MMMM yyyy}")]
		[Required(ErrorMessage = "У книги должна быть указана дата публикации")]
		[DataType(DataType.Date, ErrorMessage = "Неверный формат даты")]
		public DateTime PublishDate { get; set; }

		[DisplayName("Авторы")]
		[Required(ErrorMessage = "У книги должен ыть хотя бы один автор")]
		public virtual List<Author> Authors { get; set; }
	}
}

