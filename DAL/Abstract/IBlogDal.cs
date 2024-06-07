﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IBlogDal : IGenericDal<Blog>
    {
        List<Blog> ReadBlogsWhiteRel();
        Blog ReadBlogsWhiteRelById(int id);
    }
}
