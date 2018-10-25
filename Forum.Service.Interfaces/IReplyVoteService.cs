using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface IReplyVoteService : IService<Reply_Vote>
    {
        int AddVote(Reply_Vote vote, int userID);
        int DeleteVote(Reply_Vote vote, int userID);
        int Likes(int id);
        int Dislikes(int id);
        VoteStatus MyVoteStatus(int id, int userId);
    }
}
