using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoeStore.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        ShoeStoreEntities db = new ShoeStoreEntities();
        // GET: Admin/Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CustomerList()
        {
            var customer = db.GetAccount();
            ViewBag.CustomerList = customer;
            return View();
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult AddCustomer()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            db.AuthenticateRegister()
        //            //db.RegValid(user.username, user.pass, user.email, user.sdt, user.diachi, user.tenkh).ToString();
        //            return RedirectToAction("List");
        //        }
        //        catch (Exception)
        //        {
        //            ModelState.AddModelError("CreateFailed", "Tên tài khoản đã tồn tại !");
        //        }
        //    }
        //    return View();
        //}
    }
}