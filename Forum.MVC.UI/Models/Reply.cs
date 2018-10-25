using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Reply
    {
        public int Id { get; set; }
        public int userID { get; set; }
        public string Name { get; set; }
        public string reply { get; set; }
        public int Score { get; set; }
        public VoteStatus voteStatus { get; set; }
    }
}