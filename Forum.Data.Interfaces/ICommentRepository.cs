using Forum.Entity;
using Forum.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Data.Interfaces
{
    public interface ICommentRepository : IService<Comment>
    {
        int CommentCount(int id);
        IEnumerable<Comment> GetAllByPostId(int id);
    }
}
