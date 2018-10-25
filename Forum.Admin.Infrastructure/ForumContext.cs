using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Forum.Admin.Infrastructure
{
    public class ForumContext : DbContext
    {
        public DbSet<User> Users { set; get; }
        public DbSet<Change_Info_Request> ChangeInfoRequests { set; get; }
        public DbSet<Comment> Comments { set; get; }
        public DbSet<Complain> Complains { set; get; }
        public DbSet<Complain_Reply> ComplainReplays { set; get; }
        public DbSet<Post> Posts { set; get; }
        public DbSet<Ranking> Rankings { set; get; }
        public DbSet<Reply> Replays { set; get; }
        public DbSet<Post_Vote> PostVotes { set; get; }
        public DbSet<Reply_Vote> ReplayVotes { set; get; }
        public DbSet<Comment_Vote> CommentVotes { set; get; }
    }
}