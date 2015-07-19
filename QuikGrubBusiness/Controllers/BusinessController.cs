using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuikGrubBusiness.Controllers
{
    public class BusinessController : Controller
    {
        // GET: Business
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult UpdateInfo(long? id)
        {
            GrubDBDataContext GrubDB = new GrubDBDataContext();
            if (id == null)
            {
                //check if there are multiple restaurants associated with account, if so display list
                var associatedComps = GrubDB.selectall_company_info().Where(m => m.username == User.Identity.Name.Replace("@rose-hulman.edu","")).ToList();
                if(associatedComps.Count>1)
                {
                    Session["restaurants"] = associatedComps;
                    return RedirectToAction("RestaurantList");
                }
                if(associatedComps.Count!=1)
                {
                    return RedirectToAction("CreateRestaurant");
                }
                //otherwise show the restaurant associated with the account
                id = associatedComps[0].id;
            }
            var model = GrubDB.selectall_with_id_company_info(id).ToList()[0];
            return View(convert(model));
        }
        [HttpPost]
        public ActionResult UpdateInfo(company_info model)
        {
            GrubDBDataContext GrubDB = new GrubDBDataContext();
            GrubDB.update_company_info(model.id, model.delivery, model.location, model.name, model.orders, model.owner_first, model.owner_last, model.phone_number, model.point_of_contact_email, model.point_of_contact_phone, model.payment_status, model.username);
            return RedirectToAction("index", "Home");
        }
        private company_info convert(selectall_with_id_company_infoResult model)
        {
            return new company_info { id = model.id, delivery = model.delivery, location = model.location, name = model.name, orders = model.orders, owner_first = model.owner_first, owner_last = model.owner_last, payment_status = model.payment_status, phone_number = model.phone_number, point_of_contact_email = model.point_of_contact_email, point_of_contact_phone = model.point_of_contact_phone, username = model.username };
        }
        private company_info convert(selectall_company_infoResult model)
        {
            return new company_info { id = model.id, delivery = model.delivery, location = model.location, name = model.name, orders = model.orders, owner_first = model.owner_first, owner_last = model.owner_last, payment_status = model.payment_status, phone_number = model.phone_number, point_of_contact_email = model.point_of_contact_email, point_of_contact_phone = model.point_of_contact_phone, username = model.username };
        }
        [HttpGet]
        public ActionResult RestaurantList()
        {
            ViewBag.CompanyList = (List<selectall_company_infoResult>)Session["restaurants"];
            return View();
        }
        [HttpGet]
        public ActionResult CreateRestaurant()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRestaurant(company_info model)
        {
            GrubDBDataContext GrubDB = new GrubDBDataContext();
            model.username = User.Identity.Name.Replace("@rose-hulman.edu","");
            GrubDB.create_company_info(model.delivery, model.location, model.name, model.orders, model.owner_first, model.owner_last, model.phone_number, model.point_of_contact_email, model.point_of_contact_phone, model.payment_status, model.username);
            return RedirectToAction("Index", "Home");
        }
    }
}