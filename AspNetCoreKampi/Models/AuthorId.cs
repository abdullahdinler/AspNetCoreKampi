using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;

namespace AspNetCoreKampi.Models
{
    public static class AuthorId
    {
        private static readonly AuthorManager Author = new AuthorManager(new EfAuthorDal());
        public static Author Id(string mail)
        {
            var authorId = Author.GetMailById(mail);
            var values = Author.GetById(authorId);
            return values;
        }
    }
}
