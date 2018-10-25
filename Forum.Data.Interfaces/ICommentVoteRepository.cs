using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Interfaces
{
    public interface ICommentVoteRepository : IService<Comment_Vote>
    {
        int AddVote(Comment_Vote vote, int userID);
        int DeleteVote(Comment_Vote vote, int userID);
        int Likes(int id);
        int Dislikes(int id);
        VoteStatus MyVoteStatus(int id, int userId);
    }
}
