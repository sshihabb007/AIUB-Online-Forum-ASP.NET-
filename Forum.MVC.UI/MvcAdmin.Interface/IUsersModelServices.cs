using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.MVC.UI.Models;

namespace Forum.MVC.UI.MvcAdmin.Interface
{
   public interface IUsersModelServices
    {
        bool EditInfo(Models.Users user);
        bool EditStatus(Models.Users user);
        IEnumerable<Models.Users> GetAll();
        IEnumerable<Models.Users> GetAllStudent();
        IEnumerable<Models.Users> GetAllModerator();
        IEnumerable<Models.Users> GetAllBlockuser();
        IEnumerable<Models.Users> GetAllpendinguser();
        IEnumerable<Models.Users> GetAllotheruser();
        Models.Users SelectById(String Id);
        bool Delete(Models.Users user);
    }
}
