using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class ComplainReplays
    {
        public int Id { set; get; }
        public int ComplainId { set; get; }
        public String To { set; get; }
        public String Body { set; get; }
        public int FromUser { set; get; }
        public int ToUser { set; get; }
    }
}