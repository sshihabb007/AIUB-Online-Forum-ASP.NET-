using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Forum.Admin.Service.Interface;
using Forum.Entity;

namespace Forum.Admin.Service
{
    public class RankingService : IRankingService
    {
        private DbContext _context;
        public RankingService(DbContext context)
        {
            _context = context;
        }
        public IEnumerable<Ranking> GetAll()
        {
            return _context.Set<Ranking>().ToList();
        }
    }
}
