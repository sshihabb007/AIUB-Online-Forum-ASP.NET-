using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Forum.MVC.UI.Models
{
    public class Complains:IDisposable
    {
        public int Id { get; set; }
        public int FromUser { get; set; }
        public int ToUser { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public ComplainStatus Status { get; set; }
        public NotificationStatus NotificationSeen { get; set; }
        public DateTime Date { get; set; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}