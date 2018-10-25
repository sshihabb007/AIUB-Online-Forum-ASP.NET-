using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int userID { get; set; }
        public string Name { get; set; }
        public string comment { get; set; }
        public CommentStatus Status { get; set; }
        public VoteStatus voteStatus { get; set; }
        public int Score { get; set; }
        public List<Reply> Replies { get; set; }
    }
}