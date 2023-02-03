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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal _category;

        public CategoryManager(ICategoryDal category)
        {
            _category = category;
        }

        public void Add(Category entity)
        {
            _category.Add(entity);
        }

        public void Delete(Category entity)
        {
            _category.Delete(entity);
        }

        public Category GetById(int id)
        {
            return _category.GetById(x => x.Id == id);
        }

        public List<Category> GetList()
        {
            return _category.List();
        }

        public List<Category> GetList(int id)
        {
            return _category.List(x => x.Id == id);
        }

        public void Update(Category entity)
        {
            _category.Update(entity);
        }

        public int TotalCategory()
        {
            return _category.List().Count();
        }
    }
}
