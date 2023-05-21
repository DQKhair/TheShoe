using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoeStore.Common;
using ShoeStore.Entities;
using System.Drawing;
using System.IO;

namespace ShoeStore.Controllers
{
    public class AuthController : Controller
    {
        // GET: Login
        ShoeStoreEntities db = new ShoeStoreEntities();

        public ActionResult Login()
        {
            if (Session[CommonConstants.USER_SESSION] != null)
            {
                RedirectToRoute("trangchu");
            }
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var hashPassword = db.AuthenticateLogin(username).FirstOrDefault();
            if (PasswordOption.Validation(password, hashPassword))
            {
                var admin = db.Validate_Role(username).Single();
                // khải thêm
                var checktaikhoan = db.Customers.Where(s => s.CustomerUsername == admin.Username).SingleOrDefault();
                
                //end khải thêm
                if (admin.Role == "AD")
                {
                    //khải thêm
                    Session["CheckTaiKhoan"] = checktaikhoan;
                    //end khải thêm
                    Session.Add(CommonConstants.USER_SESSION, admin);
                    return Redirect("~/Admin/Product/manager");
                }
                else
                {
                    //khải thêm
                    Session["CheckTaiKhoan"] = checktaikhoan;
                    //end khải thêm
                    var usersession = db.Get_session(username).First();
                    Session.Add(CommonConstants.USER_SESSION, usersession);
                    return RedirectToRoute("trangchu");
                }
            }
            else
            {
                ModelState.AddModelError("LoginFailed", "Tên đăng nhập hoặc mật khẩu không đúng !");
            }
            return View();
        }

        public ActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Signup([Bind(Include = "username, password, name, email, phone, address")] RegisterInfo registerInfo)
        {
            //MemoryStream memoryStream = new MemoryStream();
            //registerInfo.file.InputStream.CopyTo(memoryStream);

            //byte[] buffer = memoryStream.ToArray(); 
            

                var result = db.Account_Signup(registerInfo.username, PasswordOption.Encrypt(registerInfo.password), registerInfo.name, registerInfo.email, registerInfo.phone, registerInfo.address).FirstOrDefault();
                if (result != "Đăng kí thành công")
                {
                    ModelState.AddModelError("SignupFailed", result + " !");
                }
                else
                {
                    return RedirectToAction("Login");
                }       
            
            return View();
        }


        public ActionResult Logout()
        {
            Session[CommonConstants.USER_SESSION] = null;
            return RedirectToAction("Login");
        }
    }
}