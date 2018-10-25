using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Admin.Service.Interface
{
    public interface IComplainReplayService
    {
        bool Add(Complain_Reply replay);
    }
}
