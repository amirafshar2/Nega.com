﻿using BE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface ICategoryDal:IGenericDal<Category>
    {
        void Update1(Category c, int id);
    }
}
