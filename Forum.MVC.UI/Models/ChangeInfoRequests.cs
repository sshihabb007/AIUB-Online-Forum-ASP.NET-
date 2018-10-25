using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Forum.MVC.UI.Models
{
    public class ChangeInfoRequests:IDisposable
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public FieldName FieldName { get; set; }
        public string FieldValue { get; set; }
        public RequestStatus Status { get; set; }
        public string NameOfUser { set; get; }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}