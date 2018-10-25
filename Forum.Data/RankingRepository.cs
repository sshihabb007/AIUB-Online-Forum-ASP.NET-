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
    public class RankingRepository : Repository<Ranking>, IRankingRepository
    {
        private DbContext _context;
        public RankingRepository(DbContext context) : base(context)
        {
            _context = context;
        }

        public IEnumerable<Ranking> GetAllRanks()
        {
            return _context.Set<Ranking>().OrderByDescending(x => x.points);
        }

        public int GetRankById(int user_id)
        {
            return _context.Set<Ranking>().Where(r => r.user_id == user_id).Select(u => u.points).SingleOrDefault();
        }
    }
}
