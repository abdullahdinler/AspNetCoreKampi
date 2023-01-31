using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfBlogDal : GenericRepository<Blog>, IBlogDal
    {

        public List<Blog> ListCategory(Expression<Func<Blog, bool>> fitter = null)
        {
            using var c = new Context();
            return fitter == null ? c.Blogs.Include(x => x.Category).ToList() : c.Blogs.Include(x => x.Category).Where(fitter).ToList();


        }
    }
}
