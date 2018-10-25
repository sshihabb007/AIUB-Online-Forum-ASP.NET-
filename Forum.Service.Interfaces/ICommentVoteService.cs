using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface ICommentVoteService : IService<Comment_Vote>
    {
        int AddVote(Comment_Vote vote, int userID);
        int DeleteVote(Comment_Vote vote, int userID);
        int DislikeCount(int id);
        int LikeCount(int id);
        VoteStatus MyVoteStatus(int id, int userId);
    }
}
