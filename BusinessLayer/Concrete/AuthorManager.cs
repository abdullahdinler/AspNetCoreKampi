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
    public class AuthorManager : IAuthorService
    {
        readonly IAuthorDal _author;

        public AuthorManager(IAuthorDal author)
        {
            _author = author;
        }

        public void Add(Author entity)
        {
            _author.Add(entity);
        }

        public void Delete(Author entity)
        {
            _author.Delete(entity);
        }

        public Author GetById(int id)
        {
            return _author.GetById(x => x.Id == id);
        }

        public List<Author> GetList()
        {
            return _author.List();
        }

        public void Update(Author entity)
        {
            _author.Update(entity);
        }
    }
}
