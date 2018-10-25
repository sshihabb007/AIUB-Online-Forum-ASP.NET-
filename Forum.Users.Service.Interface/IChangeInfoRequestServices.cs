using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Entity;

namespace Forum.Users.Service.Interface
{
   public interface IChangeInfoRequestServices
    {
        bool Add(Change_Info_Request change);
    }
}
