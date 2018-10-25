using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Entity;

namespace Forum.Admin.Service.Interface
{
   public interface IUsersServices
    {
        bool EditInfo(User user);
        bool EditStatus(User user);
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAllStudent();
        IEnumerable<User> GetAllModerator();
        User SelectById(int Id);
        bool Delete(User user);
    }
}
