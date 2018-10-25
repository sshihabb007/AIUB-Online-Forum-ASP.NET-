using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{

    public class Posts:IDisposable
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public IHtmlString Body { get; set; }
        public int Like { get; set; }
        public int Dislike { get; set; }
        public PostStatus Status { get; set; }
        public PostActivity Activity { get; set; }
        public int UserId { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}