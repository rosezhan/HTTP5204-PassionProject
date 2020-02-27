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

        [HttpPost]
        public ActionResult Add(string Username, string Email, string FirstName, string LastName)
        {
            string query = "insert into authors (Username, Email, FirstName, LastName) values (@AuthorUser, @AuthorEmail, @AuthorFName, @AuthorLName)";
            SqlParameter[] sqlParams = new SqlParameter[4];
            sqlParams[0] = new SqlParameter("@AuthorUser", Username);
            sqlParams[1] = new SqlParameter("@AuthorEmail", Email);
            sqlParams[2] = new SqlParameter("@AuthorFName", FirstName);
            sqlParams[3] = new SqlParameter("@AuthorLName", LastName);

            db.Database.ExecuteSqlCommand(query, sqlParams);

            return RedirectToAction("List");
        }
    }
}