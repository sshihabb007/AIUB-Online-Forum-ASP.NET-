using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Interfaces
{
    public interface IPostVoteRepository : IService<Post_Vote>
    {
        int AddVote(Post_Vote vote, int userID);
        int DeleteVote(Post_Vote vote, int userID);
        int Likes(int id);
        int Dislikes(int id);
        int Nones(int id);
        VoteStatus MyVoteStatus(int postId, int userId);
    }
}
