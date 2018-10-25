using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Comments
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Comment { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public bool Status { get; set; }
    }
}