using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.Mvc.Models
{
    public class SinglePost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string Tags { get; set; }
        public int userPoint { get; set; }
        public string Name { get; set; }
        public Entity.PostActivity Status { get; set; }
    }
}