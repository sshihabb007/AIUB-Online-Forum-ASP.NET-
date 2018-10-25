using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.MVC.UI.MvcAdmin.Interface
{
    public interface IComplainModelService
    {
        IEnumerable<Complains> GetAll();
        Complains SelectById(int Id);
        bool Reject(int id);
    }
}
