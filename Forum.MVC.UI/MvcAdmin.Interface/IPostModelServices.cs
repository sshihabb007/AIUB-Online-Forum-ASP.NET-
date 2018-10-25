using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.MVC.UI.MvcAdmin.Interface
{
    public interface IPostModelServices
    {
        bool Delete(int Id);
        IEnumerable<Posts> GetAll();
        Posts SelectById(int Id);
        IEnumerable<Posts> Search(String search);
        IEnumerable<Posts> GetListByUser(string Id);
    }
}
