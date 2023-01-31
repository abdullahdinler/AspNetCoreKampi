using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        List<Blog> GetLastList();
        List<Blog> GetBlogWithCategory(int? id);
        List<Blog> GetBlogWithCategory();
        List<Blog> GetBlogWithAuthor(int id);
    }
}
