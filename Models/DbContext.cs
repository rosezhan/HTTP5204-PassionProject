using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace WritingForum.Models

{
    public class WritingContext : DbContext
    {
        public WritingContext() : base("WritingContext") { }
        public System.Data.Entity.DbSet<WritingForum.Models.Thread> Threads { get; set; }
        public System.Data.Entity.DbSet<WritingForum.Models.Author> Authors { get; set; }
    }
}
