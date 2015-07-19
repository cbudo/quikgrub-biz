using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuikGrubBusiness.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Manage()
        {
            return View();
        }
    }
}