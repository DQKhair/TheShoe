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

namespace ShoeStore.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product

        public ActionResult Manager(int? size, int? page, string sortProperty, string searchString, string sortOrder = "")
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var products = db.GetProducts(null, null).ToList();
            ViewBag.Products = products;
            // Lọc danh sách sản phẩm phù hợp với từ khóa tìm kiếm
            //if (!string.IsNullOrEmpty(searchString))
            //{
            //    var search = db.SearchProductByName(searchString);
            //    ViewBag.Products = search;
            //}

            return View();
        }
        public ActionResult ThemSanPham()
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var ListProduct = db.GetProducts(null, null);
            ViewBag.them = ListProduct;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemSanPham([Bind(Include = "ProductName, ProductPrice, ProductCategory, Description")] GetProductDetail_Result product)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            db.InsertProduct(product.ProductName, product.ProductPrice, product.ProductCategory, product.Description);
            db.SaveChanges();
            return RedirectToAction("Manager");
        }

        public ActionResult SuaSanPham(int? id)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var ListProduct = db.GetProductDetail(id).Single();
            ViewBag.sua = ListProduct;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaSanPham()
        {
            int Id = int.Parse(Request.Form["ProductID"]);
            var Name = Request.Form["ProductName"];
            double Price = double.Parse(Request.Form["ProductPrice"]);
            int Cate = int.Parse(Request.Form["ProductCategory"]);
            var Des = Request.Form["Description"];
            ShoeStoreEntities db = new ShoeStoreEntities();
            db.UpdateProduct(Id, Name, Price, Cate, Des);
            db.SaveChanges();
            return RedirectToAction("../Admin/Product/manager");
        }

        public ActionResult ThemImage(int? id)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var ListProduct = db.GetProductDetail(id).SingleOrDefault();
            ViewBag.sua = ListProduct;
            var color = db.GetColor();
            ViewBag.Color = color;
            var size = db.GetSize();
            ViewBag.Size = size;
            return View();
        }

        [HttpPost]
        public ActionResult ThemImage(HttpPostedFileBase anh)
        {
            int Id = int.Parse(Request.Form["ProductID"]);
            var ImageExtension = Request.Form["ImageExtension"];
            byte[] buffer = null;
            if (anh != null)
            {
                MemoryStream memoryStream = new MemoryStream();
                anh.InputStream.CopyTo(memoryStream);
                buffer = memoryStream.ToArray();
            }
            ShoeStoreEntities db = new ShoeStoreEntities();
            db.UploadImageToProduct(buffer, ImageExtension, Id);
            db.SaveChanges();
            return RedirectToAction("../Admin/Product/manager");
        }

        [HttpPost]
        public ActionResult ThemThongTin()
        {
            int Id = int.Parse(Request.Form["ProductID"]);
            var mau = int.Parse(Request.Form["mau"]);
            var size = int.Parse(Request.Form["size"]);
            var soluong = int.Parse(Request.Form["Soluong"]);
            ShoeStoreEntities db = new ShoeStoreEntities();
            db.addSizeColor(Id, size, mau, soluong);
            db.SaveChanges();
            return RedirectToAction("../Admin/Product/manager");
        }

        public ActionResult XoaSanPham(int? id)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var ListProduct = db.GetProductDetail(id).Single();
            ViewBag.xoa = ListProduct;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XoaSanPham(int id)
        {
            int Id = int.Parse(Request.Form["ProductID"]);
            ShoeStoreEntities db = new ShoeStoreEntities();
            db.DeleteProduct(Id);
            db.SaveChanges();
            return RedirectToAction("Manager");
        }

    }
}