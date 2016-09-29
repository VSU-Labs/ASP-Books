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

		[HttpGet]
		public ActionResult Create()
		{
			ViewBag.Authors = context.Authors;
			return View (new Book());
		}

		[HttpPost]
		public ActionResult Edit([Bind(Include = "BookId, Title, PublishDate")]Book book)
		{
			ViewBag.Authors = context.Authors;
			ViewBag.Title = book.Title;

			string[] authorsId = Request.Form.GetValues ("Authors");
			if (authorsId == null)
				return View (book);
			
			foreach (String stringId in authorsId) {
				int id = Int32.Parse (stringId);
				Author author = context.Authors.Find (id);
				book.Authors.Add (author);
			}

			if (!ModelState.IsValid)
				return View (book);

			Book oldBook = context.Books.Find (book.BookId);
			if (oldBook != null)
				oldBook.Clone (book);
			else
				context.Books.Add (book);
			
			context.SaveChanges ();
			return RedirectToAction("Index");
		}
	}
}

