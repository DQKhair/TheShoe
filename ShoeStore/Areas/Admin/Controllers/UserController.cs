using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using ShoeStore.Models;

namespace ShoeStore.Controllers
{
    public class UserController : Controller
    {
        ShoeStoreEntities db = new ShoeStoreEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CustomerList()
        {
            var customer = db.GetCustomer();
            ViewBag.CustomerList = customer;
            return View();
        }

        public ActionResult AddCustomer()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCustomer(string a)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //db.RegValid(user.username, user.pass, user.email, user.sdt, user.diachi, user.tenkh).ToString();
                    return RedirectToAction("List");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("CreateFailed", "Tên tài khoản đã tồn tại !");
                }
            }
            return View();
        }
    }
}