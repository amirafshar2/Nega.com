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
            throw new NotImplementedException();
        }

        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public List<Comment> GetAll()
        {
            throw new NotImplementedException();
        }

        public Comment GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
