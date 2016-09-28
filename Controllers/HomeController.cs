using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;
using Books.DAL;
using Books.Models;

namespace Books.Controllers
{
	public class HomeController : Controller
	{
		private BooksContext context = new BooksContext();

		public ActionResult Index ()
		{
			ViewBag.Books = context.Books;
			ViewBag.Authors = context.Authors;
			return View (context.Books);
		}

		[HttpGet]
		public ActionResult ShowAuthors (int id)
		{
			Book book = context.Books.Find (id);
			ViewBag.Title = book.Title;
			return View (book.Authors);
		}

		[HttpGet]
		public ActionResult Delete(int id)
		{
			Book book = context.Books.Find (id);
			context.Books.Remove (book);
			context.SaveChanges ();
			return RedirectToAction("Index");
		}

		[HttpGet]
		public ActionResult Edit(int id)
		{
			Book book = context.Books.Find (id);
			ViewBag.Authors = context.Authors;
			ViewBag.Title = book.Title;
			return View (book);
		}

		[HttpPost]
		public ActionResult Edit([Bind(Include = "BookId, Title, PublishDate")]Book book)
		{
			ViewBag.Authors = context.Authors;
			ViewBag.Title = book.Title;

			if (!ModelState.IsValid)
				return View (book);

			string[] authorsId = Request.Form.GetValues ("Authors");
			foreach (String stringId in authorsId) {
				int id = Int32.Parse (stringId);
				Author author = context.Authors.Find (id);
				book.Authors.Add (author);
			}

			Book oldBook = context.Books.Find (book.BookId);
			oldBook.Clone(book);
			context.SaveChanges ();
			return RedirectToAction("Index");
		}
	}
}

