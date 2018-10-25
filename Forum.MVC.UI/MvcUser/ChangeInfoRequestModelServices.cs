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
    public class ChangeInfoRequestModelServices : IChangeInfoRequestModelServices
    {
        private IChangeInfoRequestServices _services;
        public ChangeInfoRequestModelServices(IChangeInfoRequestServices services)
        {
            _services = services;
        }
        public bool Add(ChangeInfoRequests changeInfoRequests)
        {
            Change_Info_Request change = new Change_Info_Request();
            change.field_name = changeInfoRequests.FieldName;
            change.field_value = changeInfoRequests.FieldValue;
            change.status = changeInfoRequests.Status;
            change.user_id = changeInfoRequests.UserId;
            return _services.Add(change);
        }
    }
}