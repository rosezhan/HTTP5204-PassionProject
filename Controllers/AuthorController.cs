using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WritingForum.Models;

namespace WritingForum.Controllers
{
    public class AuthorController : Controller
    {
        private WritingContext db = new WritingContext();

        //Only showing individual authors is needed, no list. List is only provided when making a new thread.
        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Author Author = db.Authors.SqlQuery("Select * from Authors Where authorid = @AuthorID", new SqlParameter("@AuthorID", id)).FirstOrDefault();
            if (Author == null)
            {
                return HttpNotFound();
            }
            return View(Author);
        }
    }
}