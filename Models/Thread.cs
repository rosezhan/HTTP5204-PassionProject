using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WritingForum.Models
{
    public class Thread
    {
        /*A thread is created by the administrator who then chooses who the author is. An author is able to edit
         delete threads. 
         Things in Thread
                - Title
                - Date (set automatically when thread is created)
                - Status (open by default, can only be changed after thread has already been posted)

            Threads table refrences Authors Table and Topics Table*/

        [Key]

        public int ThreadID { get; set; }

        public string Title { get; set; }

        public DateTime Date { get; set; }

        public string Status { get; set; }

        //Many Threads to One Author
        public int AuthorID { get; set; }
        [ForeignKey("AuthorID")]

        public virtual Author Author { get; set; }

        //One Thread to One Topic

    }
}