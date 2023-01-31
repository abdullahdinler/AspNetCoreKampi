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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _contact;

        public ContactManager(IContactDal contact)
        {
            _contact = contact;
        }

        public Contact GetById(int id)
        {
            return _contact.GetById(x => x.Id == id);
        }

        public void Add(Contact entity)
        {
            _contact.Add(entity);
        }

        public void Delete(Contact entity)
        {
            _contact.Delete(entity);
        }

        public List<Contact> GetList()
        {
            return _contact.List();
        }

        public List<Contact> GetList(int id)
        {
            return _contact.List(x => x.Id == id);
        }

        public void Update(Contact entity)
        {
            _contact.Update(entity);
        }
    }
}
