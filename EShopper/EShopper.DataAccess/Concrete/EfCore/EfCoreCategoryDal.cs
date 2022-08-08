using EShopper.DataAccess.Abstract;
using EShopper.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EShopper.DataAccess.Concrete.EfCore
{
    public class EfCoreCategoryDal : EfCoreGenericRepository<Category, DataContext>, ICategoryDal
    {
        public void DeleteFromCategory(int categoryId, int productId)
        {
           using(var context = new DataContext())
            {
                var cmd = @"delete from ProductCategory where ProductId=@p0 and CategoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd, productId, categoryId);
            }
        }

        public Category GetByWithProducts(int id)
        {
            using(var context = new DataContext())
            {
                return context.Categories
                        .Where(i => i.Id == id)
                        .Include(i => i.ProductCategories)
                        .ThenInclude(i => i.Product)
                        .FirstOrDefault();
            }
        }
    }
}
