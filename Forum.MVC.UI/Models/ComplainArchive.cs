using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.Web.Mvc.Models
{
    public class ComplainArchive
    {
        public List<CustomComplain> fromMe { get; set; }
        public List<CustomComplain> AboutMe { get; set; }
    }
}