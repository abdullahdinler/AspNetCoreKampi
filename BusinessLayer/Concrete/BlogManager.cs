using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal _blog;

        public BlogManager(IBlogDal blog)
        {
            _blog = blog;
        }

        public void Add(Blog entity)
        {
            _blog.Add(entity);
        }

        public void Delete(Blog entity)
        {
            _blog.Delete(entity);
        }

        public List<Blog> GetBlogWithAuthor(int id)
        {
            return _blog.ListCategory(x=>x.AuthorId == id);
        }

        public int TotalBlog()
        {
            return _blog.List().Count();
        }

        public List<Blog> GetBlogWithCategory(int? id)
        {
            return _blog.ListCategory(x=>x.Id == id);
        }

        public List<Blog> GetBlogWithCategory()
        {
            return _blog.ListCategory();
        }

        
        public Blog GetById(int id)
        {
            return _blog.GetById(x => x.Id == id);
        }

        public List<Blog> GetList()
        {
            return _blog.List();
        }

        //public List<Blog> GetLastList()
        //{
        //    return _blog.List().TakeLast(3).ToList();
        //}

        public List<Blog> GetList(int id)
        {
            return _blog.List(x => x.Id == id);
        }

        public void Update(Blog entity)
        {
            _blog.Update(entity);
        }

        public int AuthorTotalBlog(int id)
        {
            return _blog.List(x => x.AuthorId == id).Count();
        }
    }
}
