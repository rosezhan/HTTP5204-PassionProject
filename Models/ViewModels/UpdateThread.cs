using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WritingForum.Models
{
    public class UpdateThread
    {
        //thread needs authors and thread information
        public Thread Thread { get; set; }
        public List<Author> Author { get; set; }
    }
}