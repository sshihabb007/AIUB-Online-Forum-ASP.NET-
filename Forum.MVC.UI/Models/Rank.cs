using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.Mvc.Models
{
    public class Rank
    {
        public int position { get; set; }
        public string name { get; set; }
        public Entity.Department department { get; set; }
        public int points { get; set; }
    }
}