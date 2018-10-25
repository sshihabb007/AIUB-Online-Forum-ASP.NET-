using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.MVC.UI.MvcUser.Interface
{
    public interface IComplainsModelServices
    {
        bool Addcomplain(Complains complains);
        IEnumerable<Complains> ComplainListByUser(int Id);
    }
}
