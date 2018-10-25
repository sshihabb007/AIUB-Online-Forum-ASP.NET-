using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Users.Service.Interface;
using Forum.Entity;
using System.Data.Entity;

namespace Forum.Users.Service
{
    public class ChangeInfoRequestServices:IChangeInfoRequestServices
    {
        private DbContext _context;
        public ChangeInfoRequestServices(DbContext context)
        {
            _context = context;
        }

        public bool Add(Change_Info_Request change)
        {
            var model = _context.Set<Change_Info_Request>();
            model.Add(change);
            _context.SaveChanges();
            return true;
        }
    }
}
