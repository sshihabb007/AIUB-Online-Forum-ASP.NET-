using Forum.Data;
using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service
{
    public class RankingService : Service<Ranking>, IRankingService
    {
        private RankingRepository _repo;
        public RankingService(RankingRepository repo) : base(repo)
        {
            _repo = repo;
        }

        public IEnumerable<Ranking> GetAllRanks()
        {
            return _repo.GetAllRanks();
        }

        public int GetRankById(int user_id)
        {
            return _repo.GetRankById(user_id);
        }
    }
}
