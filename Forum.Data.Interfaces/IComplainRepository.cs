using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Interfaces
{
    public interface IComplainRepository : IRepository<Complain>
    {
        IEnumerable<Complain> GetAllFromMe(int id);
        IEnumerable<Complain> GetAllAboutMe(int id);
    }
}
