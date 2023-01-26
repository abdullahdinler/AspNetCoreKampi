using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreKampi.ViewComponents.Comment
{
    [ViewComponent]
    public class CommentList : ViewComponent
    {
        private readonly CommentManager _cm = new CommentManager(new EfCommentDal());

        public IViewComponentResult Invoke(int id)
        {
            var result = _cm.GetList(id);
            return View(result);
        }
    }
}
