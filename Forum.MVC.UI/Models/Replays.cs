using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Replays
    {
        public int Id { get; set; }
        public int CommentId { get; set; }
        public string Replay { get; set; }
        public int UserId { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
    }
}