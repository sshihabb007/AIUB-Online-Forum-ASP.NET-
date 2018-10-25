using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcUser.Interface;
using Forum.Users.Service.Interface;
using Forum.Entity;

namespace Forum.MVC.UI.MvcUser
{
    public class ComplainModelServices : IComplainsModelServices
    {
        private IComplainServices _services;
        public ComplainModelServices(IComplainServices services)
        {
            _services = services;
        }
        public bool Addcomplain(Complains complains)
        {
            Complain complain = new Complain();
            complain.complain = complains.Subject;
            complain.date = complains.Date;
            complain.description = complains.Description;
            complain.from_user = complains.FromUser;
            complain.notification = complains.NotificationSeen;
            complain.status = complains.Status;
            complain.to_user = complains.ToUser;
            return _services.AddComplain(complain);

        }

        public IEnumerable<Complains> ComplainListByUser(int Id)
        {
            var clist = new List<Complains>();
            var comlist = _services.ComplainListByUser(Id);
            foreach(var item in comlist)
            {
                using (Complains complains = new Complains())
                {
                    complains.Date = item.date;
                    complains.Description = item.description;
                    complains.FromUser = item.from_user;
                    complains.Id = item.complain_id;
                    complains.Subject = item.complain;
                    complains.ToUser = item.to_user;
                    complains.NotificationSeen = item.notification;
                    complains.Status = item.status;
                    clist.Add(complains);
                }
            }
            return clist;
        }
    }
}