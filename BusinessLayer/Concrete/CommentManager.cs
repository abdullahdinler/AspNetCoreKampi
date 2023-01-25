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
    public class CommentManager:ICommentService
    {
        private readonly ICommentDal _comment;

        public CommentManager(ICommentDal comment)
        {
            _comment = comment;
        }

        public void Add(Comment entity)
        {
            _comment.Add(entity);
        }

        public void Delete(Comment entity)
        {
            _comment.Delete(entity);
        }

        public Comment GetById(int id)
        {
            return _comment.GetById(x => x.Id == id);
        }

        public List<Comment> GetList()
        {
            return _comment.List();
        }

        public List<Comment> GetList(int id)
        {
            return _comment.List(x=>x.BlogId == id);
        }

        public void Update(Comment entity)
        {
            _comment.Update(entity);
        }
    }
}
