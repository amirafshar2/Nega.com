﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICommentDal :IGenericDal<Comment>
    {
        List<Comment> GetCommentWithRelation(int Blogİd);
    }
}
