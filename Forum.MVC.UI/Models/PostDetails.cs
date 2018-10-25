using Forum.Entity;
using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.Mvc.Models
{
    public class PostDetails
    {
        public int Id { get; set; }
        public int userID { get; set; }
        public int userPoint { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Tag { get; set; }
        public PostStatus Status { get; set; }
        public VoteStatus MyVote { get; set; }
        public int Score { get; set; }
        public bool myPost { get; set; }
        public List<MVC.UI.Models.Comment> comments { get; set; }
    }
}