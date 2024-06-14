using BE;
using BLL.Abstract;
using DAL.Context;
using DAL.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EntityFrameWork
{
    public class EFReplayRepository : GenericRepository<Reply>, IReplayDAL
    {
        DB db = new DB();
        public List<Reply> Replay_bay_comment_id(int id)
        {
            return db.Replies.Include(z=>z.User).Where(P=>P.CommentId == id).ToList();
        }
    }
}
