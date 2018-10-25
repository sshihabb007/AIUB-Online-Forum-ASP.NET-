using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcUser.Interface;
using Forum.Users.Service.Interface;

namespace Forum.MVC.UI.MvcUser
{
    public class UserModelServices : IUsersModelServices
    {
        private IUserServices _services;
        public UserModelServices(IUserServices services)
        {
            _services = services;
        }
        public bool ChangePassById(int id, string OldPaddwors, string NewPassword)
        {
            return _services.ChangePassById(id, OldPaddwors, NewPassword);
        }

        public bool ChangePhoto(Models.Users users)
        {
            string filename = Path.GetFileName(users.Photo.FileName);
            string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Image/"), filename);
            users.PhotoUrl = "~/Image/" + filename;
            users.Photo.SaveAs(path);
            Entity.User user = new Entity.User();
            user.user_id = users.Id;
            user.photo = users.PhotoUrl;
            return _services.ChangePhoto(user);

        }

        public Models.Users GetById(int id)
        {
            var model = _services.GetByID(id);
            var user = new Models.Users();
            user.Address = model.address;
            user.BloodGroup = model.blood_group;
            user.CGPA = model.cgpa;
            user.DateOfBirth = model.dateOfBirth;
            user.Department = model.department;
            user.Email = model.email;
            user.Gender = model.gender;
            user.Id = model.user_id;
            user.LastLogin = model.last_login;
            user.LastLogout = model.last_logout;
            user.LastPost = model.last_posted;
            user.Name = model.full_name;
            user.Phone = model.phone;
            user.PhotoUrl = model.photo;
            user.Religion = model.religion;
            user.Status = model.status;
            user.UserType = model.user_type;
            user.user_name = model.user_name;
            return user;
        }
    }
}