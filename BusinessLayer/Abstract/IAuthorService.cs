using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService
    {
        List<Author> GetList();
        Author AuthorLogin(string mail,string password);
        Author GetById(int id);
        void Add(Author entity);
        void Delete(Author entity);
        void Update(Author entity);
    }
}
