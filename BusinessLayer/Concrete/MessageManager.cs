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
    public class MessageManager : IMessageService
    {
        private readonly IMessageDal _message;

        public MessageManager(IMessageDal message)
        {
            _message = message;
        }

        public List<MessageTwo> GetList()
        {
            return _message.List();
        }

        public List<MessageTwo> GetList(int id)
        {
            return _message.List(x => x.Id == id);
        }

        public MessageTwo GetById(int id)
        {
            return _message.GetById(x => x.Id == id);
        }

        public void Add(MessageTwo entity)
        {
            _message.Add(entity);
        }

        public void Delete(MessageTwo entity)
        {
            _message.Delete(entity);
        }

        public void Update(MessageTwo entity)
        {
            _message.Update(entity);
        }

        public List<MessageTwo> GetByAuthorMessage(int id)
        {
            return _message.GetListByAuthorMessage(id);
        }

    }
}
