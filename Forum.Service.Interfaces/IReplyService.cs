using Forum.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Service.Interfaces
{
    public interface IReplyService : IService<Reply>
    {
        int LikeCount(int id);
        int DislikeCount(int id);
        IEnumerable<Reply> GetAllByCommentId(int id);
    }
}
