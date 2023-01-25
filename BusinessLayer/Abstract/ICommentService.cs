using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICommentService
    {
        List<Comment> GetList();
        List<Comment> GetList(int id);
        Comment GetById(int id);
        void Add(Comment entity);
        void Delete(Comment entity);
        void Update(Comment entity);
    }
}
