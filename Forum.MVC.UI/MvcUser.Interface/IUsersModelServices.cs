using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Forum.MVC.UI;
using Forum.MVC.UI.Models;

namespace Forum.MVC.UI.MvcUser.Interface
{
    public interface IUsersModelServices
    {
        Models.Users GetById(int id);
        bool ChangePassById(int id, String OldPaddwors, String NewPassword);
        bool ChangePhoto(Models.Users users);
    }
}