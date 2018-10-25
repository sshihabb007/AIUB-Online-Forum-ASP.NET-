using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.MVC.UI.MvcAdmin.Interface
{
    public interface IComplainReplaysModelService
    {
        bool Add(ComplainReplays replay);
        ComplainReplays Preadd(int id);
    }
}
