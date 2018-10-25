using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;
using Forum.Admin.Service.Interface;

namespace Forum.MVC.UI.MvcAdmin
{
    public class ComplainModelServices : IComplainModelService
    {
        private IComplainService _complainService;

        public ComplainModelServices()
        {
        }

        public ComplainModelServices(IComplainService complainService)
        {
            _complainService = complainService;
        }

        public IEnumerable<Complains> GetAll()
        {
           var model= _complainService.GetAll();
            var lst = new List<Complains>();
            foreach (var item in model)
            {
                using (Complains com = new Complains())
                {
                    com.Date = item.date;
                    com.Description = item.description;
                    com.FromUser = item.from_user;
                    com.Id = item.complain_id;
                    com.NotificationSeen = item.notification;
                    com.Status = item.status;
                    com.Subject = item.complain;
                    com.ToUser = item.to_user;
                    lst.Add(com);
                }
            }
            return lst;
        }

        public bool Reject(int id)
        {
            return _complainService.Reject(id);
        }

        public IEnumerable<Complains> Search(string Search)
        {
            var model = _complainService.Search(Search);
            var lst = new List<Complains>();
            foreach (var item in model)
            {
                using (Complains com = new Complains())
                {
                    com.Date = item.date;
                    com.Description = item.description;
                    com.FromUser = item.from_user;
                    com.Id = item.complain_id;
                    com.NotificationSeen = item.notification;
                    com.Status = item.status;
                    com.Subject = item.complain;
                    com.ToUser = item.to_user;
                    lst.Add(com);
                }
            }
            return lst;
        }

        public Complains SelectById(int Id)
        {
            var item = _complainService.SelectById(Id);
            var com = new Complains();
            com.Date = item.date;
            com.Description = item.description;
            com.FromUser = item.from_user;
            com.Id = item.complain_id;
            com.NotificationSeen = item.notification;
            com.Status = item.status;
            com.Subject = item.complain;
            com.ToUser = item.to_user;
            return com;
        }
    }
}