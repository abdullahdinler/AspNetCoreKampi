using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IBlogService
    {
        List<Blog> GetList();
        List<Blog> GetList(int id);
        Blog GetById(int id);
        void Add(Blog entity);
        void Delete(Blog entity);
        void Update(Blog entity);
        List<Blog> GetBlogWithCategory();
        List<Blog> GetBlogWithAuthor(int id);
    }
}
