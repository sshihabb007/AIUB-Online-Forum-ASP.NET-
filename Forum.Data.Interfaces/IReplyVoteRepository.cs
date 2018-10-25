using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Interfaces
{
    public interface IReplyVoteRepository : IService<Reply_Vote>
    {
        int AddVote(Reply_Vote vote, int userID);
        int DeleteVote(Reply_Vote vote, int userID);
        int Likes(int id);
        int Dislikes(int id);
        VoteStatus MyVoteStatus(int id, int userId);
    }
}
