using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IReplayService : IGenericServis<Reply>
    {
        List<Reply> Replay_bay_comment_id(int id);
    }
}
