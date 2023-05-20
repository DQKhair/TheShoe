using ShoeStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Protocols;

namespace ShoeStore.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products
        public ActionResult Home(int? size, int? page, string sortProperty, string searchString, string sortOrder = "")
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var newest = db.GetProducts(null,"newest").ToList();
            ViewBag.NewestProducts = newest;
            var trending = db.GetProducts(null, "trending").ToList();
            ViewBag.TrendingProducts = trending;

            // Lọc danh sách sản phẩm phù hợp với từ khóa tìm kiếm
            if (!string.IsNullOrEmpty(searchString))
            {
                var searchResult = db.SearchProductByName(searchString);
                ViewBag.NewestProducts = searchResult;

                searchResult = db.SearchProductByName(searchString);
                ViewBag.TrendingProducts = searchResult;
            }

            return View();
        }
        public ActionResult List(string category, string searchString)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var product =db.GetProducts(null, category).ToList();
            ViewBag.Category = (category!=null)?category:"Colection"+$" ({product.Count})";
            ViewBag.Product = product;
            if (!string.IsNullOrEmpty(searchString))
            {
                //var searchResult = db.SearchProductByName(searchString);
                //ViewBag.Category = searchResult;

                var searchResult = db.SearchProductByName(searchString);
                ViewBag.Product = searchResult;
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            ShoeStoreEntities db = new ShoeStoreEntities();
            var detail = db.GetProductDetail(id).Single();
            ViewBag.ProductDetail = detail;
            var img = db.GetImageToCart(id).Single();
            ViewBag.Img = img;
            var size = db.GetSizeOfProduct(id);
            ViewBag.Size = size;
            var color = db.GetColorOfProduct(id);
            ViewBag.Color = color;
            return View();
        }
        
    }
}