using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
   public interface IMessageDal :IRepository<MessageTwo>
   {
       List<MessageTwo> GetListByAuthorMessage(int id);
    }
}
