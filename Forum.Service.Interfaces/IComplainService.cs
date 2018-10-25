using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface IComplainService : IService<Complain>
    {
        IEnumerable<Complain> GetAllFromMe(int id);
        IEnumerable<Complain> GetAllAboutMe(int id);
    }
}
