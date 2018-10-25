using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ChangeInfoRequestRepository : Repository<Change_Info_Request>
    {
        public ChangeInfoRequestRepository(DbContext context) : base(context)
        {
        }
    }
}
