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
	}
}

