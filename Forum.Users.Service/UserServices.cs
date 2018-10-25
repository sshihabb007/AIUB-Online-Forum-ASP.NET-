using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Users.Service.Interface;
using Forum.Entity;
using System.Data.Entity;
using Forum.Admin.Infrastructure;


namespace Forum.Users.Service
{
    public class UserServices : IUserServices
    {
        private DbContext _context;
        private PasswordProtect protect = new PasswordProtect();
        public UserServices(DbContext context)
        {
            _context = context;
        }
        public bool ChangePassById(int Id, string OldPassword, string NewPassword)
        {
            var user = _context.Set<User>().Where(u => u.user_id == Id).SingleOrDefault();
            var pass = protect.CalculateMD5Hash(OldPassword);
            var newpass = protect.CalculateMD5Hash(NewPassword);
            if (user.password == pass)
            {
                user.password = newpass;
                _context.SaveChanges();
                return true;
            }
            else
                return false;
        }

        public bool ChangePhoto(User user)
        {
            var usr = _context.Set<User>().Where(u => u.user_id == user.user_id).SingleOrDefault();
            usr.photo = user.photo;
            _context.SaveChanges();
            return true;
        }

        public User GetByID(int Id)
        {
            return _context.Set<User>().Where(u => u.user_id == Id).SingleOrDefault();
        }
    }
}
