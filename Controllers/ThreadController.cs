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
    }
}