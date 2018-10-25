using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Admin.Service.Interface
{
    public interface IComplainService
    {
        IEnumerable<Complain> GetAll();
        Complain SelectById(int Id);
        IEnumerable<Complain> Search(String Search);
        bool Reject(int id);
    }
}
