﻿using EShopper.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.DataAccess.Abstract
{
    public interface ICategoryDal : IRepository<Category>
    {
        Category GetByWithProducts(int id);
        void DeleteFromCategory(int categoryId, int productId);
    }
}