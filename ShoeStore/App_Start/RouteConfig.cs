using GiaoHang.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ShoeStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            //Cái này Phúc tự thêm hết mấy cái bên dưới vào nha
            //Mẫu:
            //RouteItem.routesList.Add(new RouteItem("Tên route", "đường dẫn", "Controller", "Action"));
            //
            //Home Controller
                
            //ProductsController
                
            //...

            //Ví dụ:
            /*routes.MapRoute(
              name: "trangchu",
              url: "trangchu",
              defaults: new
              {
                  action = "Home",
                  controller = "Products"
              }
            );
            ====> RouteItem.routesList.Add(new RouteItem("trangchu", "trangchu", "Products", "Home"));
             */

            //Mấy cái phần liên quan tới admin thì Phúc qua bên area Admin nha
            //Areas/Admin/AdminAreaRegistration.cs





            // Tự động thêm route bên trên 
            //foreach (var item in RouteItem.customerRoutes)
            //{
            //    routes.MapRoute(
            //        name: item.Name,
            //        url: item.Url,
            //        defaults: new { controller = item.Controler, action = item.Action, id = UrlParameter.Optional }
            //    );
            //}








            routes.MapRoute(
              name: "trangchu",
              url: "trangchu",
              defaults: new
              {
                  action = "Home",
                  controller = "Products"
              }
            );
            routes.MapRoute(
              name: "danhsachsanpham",
              url: "danhsachsanpham",
              defaults: new
              {
                  action = "List",
                  controller = "Products"
              }
            );
            routes.MapRoute(
              name: "category",
              url: "loai/{category}",
              defaults: new
              {
                  action = "List",
                  controller = "Products",
                  category = UrlParameter.Optional
              }
            );
            routes.MapRoute(
              name: "ChiTietSanPham",
              url: "sanpham/{id}/chitiet",
              defaults: new
              {
                  action = "Details",
                  controller = "Products",
                  id = UrlParameter.Optional
              }
            );
            routes.MapRoute(
              name: "ThemGioHang",
              url: "themgiohang",
              defaults: new
              {
                  action = "AddToCart",
                  controller = "Cart"
              }
            );
            routes.MapRoute(
              name: "GioHang",
              url: "giohang",
              defaults: new
              {
                  action = "Index",
                  controller = "Cart",
                  id = UrlParameter.Optional
              }
            );
            routes.MapRoute(
              name: "ThanhToan",
              url: "ThanhToan",
              defaults: new
              {
                  action = "ThanhToan",
                  controller = "Cart",
                  id = UrlParameter.Optional
              }
            );

            routes.MapRoute(
              name: "Dangnhap",
              url: "Dangnhap",
              defaults: new
              {
                  action = "Login",
                  controller = "Login"
              }
            );
            routes.MapRoute(
              name: "Dangky",
              url: "Dangky",
              defaults: new
              {
                  action = "Signup",
                  controller = "Signup"
              }
            );
            routes.MapRoute(
              name: "DanhsachKH",
              url: "DanhsachKH",
              defaults: new
              {
                  action = "CustomerList",
                  controller = "QLKH"
              }
            );
            routes.MapRoute(
              name: "ThemKH",
              url: "ThemKH",
              defaults: new
              {
                  action = "AddCustomer",
                  controller = "QLKH"
              }
            );
            routes.MapRoute(
              name: "QLSP",
              url: "QLSP",
              defaults: new
              {
                  action = "Manager",
                  controller = "Product"
              }
            );
            routes.MapRoute(
              name: "ThemSP",
              url: "ThemSP",
              defaults: new
              {
                  action = "ThemSanPham",
                  controller = "Product"
              }
            );
            routes.MapRoute(
              name: "XoaSP",
              url: "XoaSP",
              defaults: new
              {
                  action = "XoaSanPham",
                  controller = "Product"
              }
            );
            routes.MapRoute(
              name: "SuaSP",
              url: "SuaSP",
              defaults: new
              {
                  action = "SuaSanPham",
                  controller = "Product"
              }
            );
            routes.MapRoute(
             name: "ThemAnh",
             url: "ThemAnh",
             defaults: new
             {
                 action = "ThemImage",
                 controller = "Product"
             }
           );
        
            routes.MapRoute(
            name: "ThemThongTin",
            url: "ThemThongTin",
            defaults: new { action = "ThemThongTin", controller = "Product" }
        );


            /* Ngoại lệ*/
            routes.MapRoute(
              name: "Default",
              url: "{controller}/{action}/{id}",
              defaults: new
              {
                  action = "Home",
                  controller = "Products",
                  id = UrlParameter.Optional
              });
        }
    }
}