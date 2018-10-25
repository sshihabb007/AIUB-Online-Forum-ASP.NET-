using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Admin.Service.Interface
{
    public interface IPostServices
    {
        bool Delete(int Id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetListByUser(String Id);
        Post SelectById(int Id);
        IEnumerable<Post> Search(String search);
    }
}
