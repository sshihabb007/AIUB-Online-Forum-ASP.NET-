using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.Mvc.Models
{
    public class AllPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Tag { get; set; }
        public PostStatus Status { get; set; }
        public VoteStatus MyVote { get; set; }
        public int Score { get; set; }
        public int Vote { get; set; }
        public int Response { get; set; }
        public int userID { get; set; }
        public int userPoint { get; set; }
        public string Name { get; set; }
    }
}