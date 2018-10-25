using Forum.MVC.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.MVC.UI.MvcAdmin.Interface
{
    public interface IChangeInfoRequestModelService
    {
        bool ApproveById(int Id);
        bool RejectById(int Id);
        IEnumerable<ChangeInfoRequests> GetAllList();
        ChangeInfoRequests SelectById(int id);
        Object Search(String search);
    }
}
