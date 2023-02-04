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

        public List<Message> GetList()
        {
            return _message.List();
        }

        public List<Message> GetList(int id)
        {
            return _message.List(x => x.Id == id);
        }

        public Message GetById(int id)
        {
            return _message.GetById(x => x.Id == id);
        }

        public void Add(Message entity)
        {
            _message.Add(entity);
        }

        public void Delete(Message entity)
        {
            _message.Delete(entity);
        }

        public void Update(Message entity)
        {
            _message.Update(entity);
        }

        public List<Message> GetByAuthorMessage(string p)
        {
            return _message.List(x => x.Receiver == p);
        }
    }
}
