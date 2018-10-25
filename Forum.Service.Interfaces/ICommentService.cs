using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface ICommentService : IService<Comment>
    {
        int CommentCount(int id);
        IEnumerable<Comment> GetAllByPostId(int id);
    }
}
