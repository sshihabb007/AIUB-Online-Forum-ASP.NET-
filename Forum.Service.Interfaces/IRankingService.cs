using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface IRankingService : IService<Ranking>
    {
        IEnumerable<Ranking> GetAllRanks();
        int GetRankById(int user_id);
    }
}
