using Forum.Data.Interfaces;
using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data
{
    public class ComplainRepository : Repository<Complain>, IComplainRepository
    {
        private DbContext _context;
        public ComplainRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Complain> GetAllAboutMe(int id)
        {
            return _context.Set<Complain>().Where(x=> x.to_user==id);
        }

        public IEnumerable<Complain> GetAllFromMe(int id)
        {
            return _context.Set<Complain>().Where(x => x.from_user == id);
        }
    }
}
