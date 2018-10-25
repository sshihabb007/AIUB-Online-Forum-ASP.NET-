using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Interfaces
{
    public interface IPostRepository : IService<Post>
    {
        bool EditPost(Post post);
        bool DeletePost(int id);
        bool HidePost(Post post);
        bool SolvedPost(int postId);
        bool SolvedComment(int commentId);
        IEnumerable<Post> GetAllByPostsId(int id);
    }
}
