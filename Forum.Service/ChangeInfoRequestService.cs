using Forum.Data;
using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service
{
    public class ChangeInfoRequestService : Service<Change_Info_Request>
    {
        public ChangeInfoRequestService(ChangeInfoRequestRepository repo) : base(repo)
        {
        }
    }
}
