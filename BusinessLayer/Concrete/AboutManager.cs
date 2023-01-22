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
    public class AboutManager:IAboutService
    {
        private IAboutDal _about;

        public AboutManager(IAboutDal about)
        {
            _about = about;
        }

        public void Add(About entity)
        {
            _about.Add(entity);
        }

        public void Delete(About entity)
        {
            _about.Delete(entity);
        }

        public About GetById(int id)
        {
            return _about.GetById(x=>x.Id == id);
        }

        public List<About> GetList()
        {
            return _about.List();
        }

        public List<About> GetList(int id)
        {
            return _about.List(x=>x.Id == id);
        }

        public void Update(About entity)
        {
            _about.Update(entity);
        }
    }
}
