using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface IPostService : IService<Post>
    {
        bool AddPost(Post post,int id);
        bool EditPost(Post post);
        bool DeletePost(int id);
        bool HidePost(Post post);
        bool SolvedPost(int postId);
        bool SolvedComment(int commentId);
        IEnumerable<Post> GetAllByPostsId(int id);
    }
}
