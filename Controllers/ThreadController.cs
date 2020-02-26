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
    public class ThreadController : Controller
    {
        private WritingContext db = new WritingContext();

        public ActionResult List()
        {
            var Thread = db.Threads.SqlQuery("select * from threads").ToList();
            return View(Thread);
        }

        public ActionResult Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Thread Thread = db.Threads.SqlQuery("select * from threads where threadid=@ThreadID", new SqlParameter("@ThreadID", id)).FirstOrDefault();
            if (Thread == null)
            {
                return HttpNotFound();
            }
            return View(Thread);
        }

        [System.Web.Mvc.HttpPost]
        //only Title from Threads is needed for adding a new thread, and username from authors, but the rest are still needed for the database
        public ActionResult Add(string Title, DateTime Date, string Status, int AuthorID)
        {
            string query = "insert into threads (Title, Date, Status, AuthorID) values (@ThreadTitle, @ThreadDate, @ThreadStatus, @AuthorID)";
            SqlParameter[] sqlParams = new SqlParameter[4];
            sqlParams[0] = new SqlParameter("@ThreadTitle", Title);
            sqlParams[1] = new SqlParameter("@ThreadDate", Date);
            sqlParams[2] = new SqlParameter("@ThreadStatus", Status);
            sqlParams[3] = new SqlParameter("@AuthorID", AuthorID);

            db.Database.ExecuteSqlCommand(query, sqlParams);

            return RedirectToAction("List");
        }
        //add authors
        public ActionResult New()
        {
            List<Author> author = db.Authors.SqlQuery("Select * from Authors").ToList();
            return View(author);
        }

        //status is only available on update screen
        public System.Web.Mvc.ActionResult Update(int id)
        {
            Thread selectedThread = db.Threads.SqlQuery("Select * from threads where threadID = @id", new SqlParameter("@id", id)).FirstOrDefault();
            List<Author> Author = db.Authors.SqlQuery("Select * from authors").ToList();

            UpdateThread UpdateThreadViewModel = new UpdateThread();
            UpdateThreadViewModel.Thread = selectedThread;
            UpdateThreadViewModel.Author = Author;

            return View(UpdateThreadViewModel);
        }

        public System.Web.Mvc.ActionResult Update(int id, string Title, DateTime Date, string Status, int AuthorID)
        {
            string query = "update threads set Title=@ThreadTitle, AuthorID=@AuthorID, Status=@ThreadStatus, Date=@ThreadDate, where ThreadID=@id";
            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@ThreadTitle", Title);
            sqlparams[1] = new SqlParameter("@ThreadStatus", Status);
            sqlparams[2] = new SqlParameter("@ThreadDate", Date);
            sqlparams[3] = new SqlParameter("@AuthorID", AuthorID);
            sqlparams[4] = new SqlParameter("@id", id);

            db.Database.ExecuteSqlCommand(query, sqlparams);
            return RedirectToAction("List");
        }

        public ActionResult DeleteConfirm(int id)
        {
            string query = "select * from threads where threadID = @id";
            SqlParameter param = new SqlParameter("@id", id);
            Thread selectedThread = db.Threads.SqlQuery(query, param).FirstOrDefault();

            return View(selectedThread);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            string query = "delete from threads where threadID = @id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);

            return RedirectToAction("List");
        }
    }
}