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
    public class NewsLatterManager:INewsLatterService
    {
        private readonly INewsLatterDal _nld;

        public NewsLatterManager(INewsLatterDal nld)
        {
            _nld = nld;
        }

        public void Add(NewsLetter entity)
        {
            entity.Status = true;
            _nld.Add(entity);
        }

        public void Delete(NewsLetter entity)
        {
            _nld.Delete(entity);
        }

        public NewsLetter GetById(int id)
        {
            return _nld.GetById(x => x.Id == id);
        }

        public List<NewsLetter> GetList()
        {
            return _nld.List();
        }

        public List<NewsLetter> GetList(int id)
        {
            return _nld.List(x => x.Id == id);
        }

        public void Update(NewsLetter entity)
        {
            _nld.Update(entity);
        }
    }
}
