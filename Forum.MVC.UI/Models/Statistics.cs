using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Statistics
    {
        public int Student { set; get; }
        public int Moderator { set; get; }
        public int Solved { set; get; }
        public int Unsolved { set; get; }
        public int Actioned { set; get; }
        public int Complain { set; get; }
    }
}