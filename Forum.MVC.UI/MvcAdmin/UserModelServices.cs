using System;
using System.Collections.Generic;
using System.Linq;
using Forum.Admin.Service.Interface;
using Forum.MVC.UI.Models;
using Forum.MVC.UI.MvcAdmin.Interface;
using Forum.Entity;
using System.IO;

namespace Forum.MVC.UI.MvcAdmin
{
    public class UserModelServices : IUsersModelServices
    {
        private IUsersServices _usersServices;
        public UserModelServices(IUsersServices usersServices)
        {
            _usersServices = usersServices;
        }
        public bool Delete(Models.Users user)
        {
            try
            {
                User usr = new User()
                {
                    user_id = user.Id,
                    user_name=user.user_name
                };
                _usersServices.Delete(usr);
                return true;
            }catch
            {
                return false;
            }
        }

        public bool EditInfo(Models.Users user)
        {
                if (user.Photo != null)
                {
                    string filename = Path.GetFileName(user.Photo.FileName);
                    string path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Image/"), filename);
                    user.PhotoUrl = "~/Image/" + filename;
                    user.Photo.SaveAs(path);
                }
                else
            {
                user.PhotoUrl = null;
            }
                User usr = new User()
                {
                    user_id = Convert.ToInt32(user.Id),
                    user_name=user.user_name,
                    full_name = user.Name,
                    address = user.Address,
                    blood_group = user.BloodGroup,
                    cgpa = user.CGPA,
                    dateOfBirth = user.DateOfBirth,
                    department = user.Department,
                    email = user.Email,
                    gender = user.Gender,
                    phone = user.Phone,
                    photo = user.PhotoUrl,
                    religion = user.Religion,
                    user_type=user.UserType
                };
                _usersServices.EditInfo(usr);
                return true;
            
        }

        public bool EditStatus(Models.Users user)
        {
            try
            {
                User usr = new User();
                usr.user_id = user.Id;
                usr.status = user.Status;
                _usersServices.EditStatus(usr);
                return true;
            }catch { return false; }
        }

        public IEnumerable<Models.Users> GetAll()
        {
           var model= _usersServices.GetAll();
            List<Models.Users> userslst = new List<Models.Users>();
            foreach(var item in model.AsEnumerable())
            {
                using (Models.Users users =new Models.Users())
                {
                    users.Id = item.user_id;
                    users.user_name = item.user_name;
                    users.Name = item.full_name;
                    users.UserType = item.user_type;
                    users.Status = item.status;
                    userslst.Add(users);
                }
            }
            return userslst.AsEnumerable();
        }

        public IEnumerable<Models.Users> GetAllBlockuser()
        {
            var model = _usersServices.GetAll();
            List<Models.Users> userslst = new List<Models.Users>();
            foreach (var item in model.AsEnumerable())
            {
                if(item.status==UserStatus.Blocked)
                {
                    using (Models.Users users = new Models.Users())
                    {
                        users.Id = item.user_id;
                        users.Name = item.full_name;
                        users.UserType = item.user_type;
                        users.Status = item.status;
                        userslst.Add(users);
                    }
                }
            }
            return userslst.AsEnumerable();
        }

        public IEnumerable<Models.Users> GetAllModerator()
        {
            var model = _usersServices.GetAllModerator();
            List<Models.Users> userslst = new List<Models.Users>();
            foreach (var item in model.AsEnumerable())
            {
                using (Models.Users users = new Models.Users())
                {
                    users.Id = item.user_id;
                    users.Name = item.full_name;
                    users.UserType = item.user_type;
                    users.Status = item.status;
                    userslst.Add(users);
                }
            }
            return userslst.AsEnumerable();

        }

        public IEnumerable<Models.Users> GetAllotheruser()
        {
            var model = _usersServices.GetAll();
            List<Models.Users> userslst = new List<Models.Users>();
            foreach (var item in model.AsEnumerable())
            {
                if (item.status != UserStatus.Blocked && item.status!= UserStatus.Pending)
                {
                    using (Models.Users users = new Models.Users())
                    {
                        users.Id = item.user_id;
                        users.Name = item.full_name;
                        users.UserType = item.user_type;
                        users.Status = item.status;
                        userslst.Add(users);
                    }
                }
            }
            return userslst.AsEnumerable();
        }

        public IEnumerable<Models.Users> GetAllpendinguser()
        {
            var model = _usersServices.GetAll();
            List<Models.Users> userslst = new List<Models.Users>();
            foreach (var item in model.AsEnumerable())
            {
                if (item.status == UserStatus.Pending)
                {
                    using (Models.Users users = new Models.Users())
                    {
                        users.Id = item.user_id;
                        users.Name = item.full_name;
                        users.UserType = item.user_type;
                        users.Status = item.status;
                        userslst.Add(users);
                    }
                }
            }
            return userslst.AsEnumerable();
        }

        public IEnumerable<Models.Users> GetAllStudent()
        {
            var model = _usersServices.GetAllStudent();
            List<Models.Users> userslst = new List<Models.Users>();
            foreach (var item in model.AsEnumerable())
            {
                using (Models.Users users = new Models.Users())
                {
                    users.Id = item.user_id;
                    users.Name = item.full_name;
                    users.UserType = item.user_type;
                    users.Status = item.status;
                    userslst.Add(users);
                }
            }
            return userslst.AsEnumerable();

        }

        public Models.Users SelectById(String Id)
        {
            var user = _usersServices.SelectById(Convert.ToInt32(Id));
            Models.Users users;
                users = new Models.Users
                {
                    Id=user.user_id,
                    Name = user.full_name,
                    Email = user.email,
                    Phone = user.phone,
                    DateOfBirth = user.dateOfBirth,
                    Gender = user.gender,
                    BloodGroup = user.blood_group,
                    Religion = user.religion,
                    Address = user.address,
                    UserType=user.user_type,
                    CGPA=user.cgpa,
                    Status=user.status,
                    Department = user.department,
                    PhotoUrl = user.photo,
                    LastLogin = user.last_login,
                    LastLogout = user.last_logout,
                    LastPost = user.last_posted
                };
                return users;
            }
    }
}