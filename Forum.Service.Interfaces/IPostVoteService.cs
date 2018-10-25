using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface IPostVoteService : IService<Post_Vote>
    {
        int AddVote(Post_Vote vote, int userID);
        int DeleteVote(Post_Vote vote, int userID);
        int LikeCount(int id);
        int DislikeCount(int id);
        int NoneCount(int id);
        VoteStatus MyVoteStatus(int postId, int userId);
    }
}
