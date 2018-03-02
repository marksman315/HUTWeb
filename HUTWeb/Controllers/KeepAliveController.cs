using System.Web.Mvc;
using HUTWeb.Handlers;

namespace HUTWeb.Controllers
{
    public class KeepAliveController : Controller
    {
        //GET: KeepAlive
        [HttpGet]
        public JsonResult KeepAlive()
        {
            KeepAliveHandler handler = new KeepAliveHandler();
            string text = handler.GetKeepAlive();

            return Json(text, JsonRequestBehavior.AllowGet);
        }        
    }
}
