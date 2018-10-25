using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Interfaces
{
    public interface IUserRepository : IService<User>
    {
        bool EditLastPost(int id);
    }
}
