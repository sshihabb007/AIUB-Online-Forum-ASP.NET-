using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Entity;

namespace Forum.Users.Service.Interface
{
   public interface IUserServices
    {
        User GetByID(int Id);
        bool ChangePassById(int Id, string OldPassword,string NewPassword);
        bool ChangePhoto(User user);
    }
}
