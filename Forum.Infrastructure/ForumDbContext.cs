using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Infrastructure
{
    public class ForumDbContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Reply> Reply { get; set; }
        public DbSet<Post_Vote> Post_Vote { get; set; }
        public DbSet<Comment_Vote> Comment_Vote { get; set; }
        public DbSet<Reply_Vote> Reply_Vote { get; set; }
        public DbSet<Ranking> Ranking { get; set; }
        public DbSet<Complain> Complain { get; set; }
        public DbSet<Complain_Reply> Complain_Replie { get; set; }
        public DbSet<Change_Info_Request> Change_Info_Request { get; set; }
    }
}
