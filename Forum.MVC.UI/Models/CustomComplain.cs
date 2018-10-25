using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.Mvc.Models
{
    public class CustomComplain
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public Entity.ComplainStatus Status { get; set; }
        public DateTime date { get; set; }
    }
}