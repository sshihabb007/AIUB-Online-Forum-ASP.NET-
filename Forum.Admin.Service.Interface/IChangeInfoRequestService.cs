using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Admin.Service.Interface
{
    public interface IChangeInfoRequestService
    {
        bool ApproveById(int Id);
        bool RejectById(int Id);
        IEnumerable<Change_Info_Request> GetAllList();
        Change_Info_Request SelectById(int id);
    }
}
