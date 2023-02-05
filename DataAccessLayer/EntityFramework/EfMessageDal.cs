using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.EntityFramework
{
    public class EfMessageDal : GenericRepository<MessageTwo>, IMessageDal
    {
        public List<MessageTwo> GetListByAuthorMessage(int id)
        {
            using var c = new Context();
            return c.MessageTwos.Include(x => x.SenderUser).Where(x=>x.ReceiverId == id).ToList();

        }
    }
}
