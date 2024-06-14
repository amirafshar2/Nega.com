using BE;
using BLL.Abstract;
using DAL.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrate
{
    public class ReplayManager : IReplayService
    {
        IReplayDAL _DAL;

        public ReplayManager(IReplayDAL dAL)
        {
            _DAL = dAL;
        }

        public void Add(Reply t)
        {
            _DAL.Add(t);
        }

        public void Delete(Reply t)
        {
            _DAL.Delete(t);
        }

        public List<Reply> GetAll()
        {
            return _DAL .GetAll();
        }

        public Reply GetById(int id)
        {
            return _DAL.GetBayId(id);
        }

        public List<Reply> Replay_bay_comment_id(int id)
        {
            return _DAL.Replay_bay_comment_id(id);
        }

        public void Update(Reply t)
        {
            _DAL.Update(t);
        }
    }
}
