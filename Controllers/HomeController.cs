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
			return View ();
		}
	}
}

