using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IBlogDal:IRepository<Blog>
    {
        List<Blog> ListCategory(Expression<Func<Blog, bool>> fitter = null);
    }
}
