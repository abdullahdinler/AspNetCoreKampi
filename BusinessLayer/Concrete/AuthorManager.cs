using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;

namespace BusinessLayer.Concrete
{
    public class AuthorManager : IAuthorService
    {

        private readonly IAuthorDal _author;

        public AuthorManager(IAuthorDal author)
        {
            _author = author;
        }

        public void Add(Author entity)
        {
            _author.Add(entity);
        }

        public Author AuthorLogin(string mail, string password)
        {
            var result = _author.List().FirstOrDefault(x => x.Mail == mail && x.Password == password);
            return result;
        }

        public int GetMailById(string mail)
        {
            return _author.List(x => x.Mail == mail).Select(y => y.Id).FirstOrDefault();
        }


        public void Delete(Author entity)
        {
            _author.Delete(entity);
        }

        public List<Author> GetList(int id)
        {
            return _author.List(x => x.Id == id);
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
