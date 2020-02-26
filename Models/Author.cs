using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WritingForum.Models
{
    public class Author
    {
        /*An author is some who can post threads and topics, and go back and edit them. Only the administrator can add
         and delete authors. Authors can edit their own profile. 
         Things that describe authors:
                - Username
                - Password
                - Email
                - About
                - First Name
                - Last Name
                
         Author table must reference Thread and Topic tables*/

        [Key]
        public int AuthorID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string About { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //One Author to Many Threads

        public int ThreadID { get; set; }
        [ForeignKey("ThreadID")]

        public virtual Thread Thread { get; set; }

        //One Author to Many Topics
    }
}