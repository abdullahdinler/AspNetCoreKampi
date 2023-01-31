using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IAuthorService:IGenericService<Author>
    {
        Author AuthorLogin(string mail,string password);
    }
}
