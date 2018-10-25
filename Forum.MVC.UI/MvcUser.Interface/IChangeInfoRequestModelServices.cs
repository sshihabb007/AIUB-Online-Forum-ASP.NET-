using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.MVC.UI.MvcUser.Interface
{
    public interface IChangeInfoRequestModelServices
    {
        bool Add(ChangeInfoRequests changeInfoRequests);
    }
}
