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
    public class CommentManager : ICommentService
    {
        ICommentDal _ıcommentdal;

        public CommentManager(ICommentDal ıcommentdal)
        {
            _ıcommentdal = ıcommentdal;
        }

        public void Add(Comment t)
        {
            _ıcommentdal.Add(t);
        }

        public void Delete(Comment t)
        {
            _ıcommentdal.Delete(t);
        }

        public List<Comment> GetAll()
        {
           return _ıcommentdal.GetAll();
        }

        public Comment GetById(int id)
        {
            return _ıcommentdal.GetBayId(id);
        }

        public void Update(Comment t)
        {
            _ıcommentdal.Update(t);
        }
    }
}
