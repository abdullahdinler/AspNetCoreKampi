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
    public class AdminManager:IAdminService
    {
        private readonly IAdminDal _admin;

        public AdminManager(IAdminDal admin)
        {
            _admin = admin;
        }

        public List<Admin> GetList()
        {
            return _admin.List();
        }

        public List<Admin> GetList(int id)
        {
            return _admin.List(x=>x.Id == id);
        }

        public Admin GetById(int id)
        {
            return _admin.GetById(x => x.Id == id);
        }

        public void Add(Admin entity)
        {
            _admin.Add(entity);
        }

        public void Delete(Admin entity)
        {
            _admin.Delete(entity);
        }

        public void Update(Admin entity)
        {
            _admin.Update(entity);
        }
    }
}
