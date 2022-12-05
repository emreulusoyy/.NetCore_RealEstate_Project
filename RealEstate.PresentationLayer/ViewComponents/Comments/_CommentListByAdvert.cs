using Microsoft.AspNetCore.Mvc;
using RealEstate.DataAccessLayer.Concrete;
using System.Linq;

namespace RealEstate.PresentationLayer.ViewComponents.Comments
{
    public class _CommentListByAdvert:ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            Context context = new Context();
            var values = context.Comments.Where(x => x.ProductID == id).ToList();
            return View(values);
        }
    }
}
