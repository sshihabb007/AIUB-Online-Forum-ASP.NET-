using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Rankings:IDisposable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int Point { get; set; }
        public String Name { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}