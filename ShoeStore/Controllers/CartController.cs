using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoeStore.Common;
using ShoeStore.Models;

namespace ShoeStore.Controllers
{
    public class CartController : Controller
    {
        ShoeStoreEntities db = new ShoeStoreEntities();
        public ActionResult ShowCart()
        {
           
            if (Session["Cart"] == null)
                return View("EmptyCart");
            Carts _cart = Session["Cart"] as Carts;
            return View(_cart);
        }
        public ActionResult EmptyCart()
        {
            return View();
        }
        public Carts GetCart()
        {
            Carts cart = Session["Cart"] as Carts;
            if (cart == null || Session["Cart"] == null)
            {
                cart = new Carts();
                Session["Cart"] = cart;
            }
            return cart;
        }
        public ActionResult AddToCart(int id, FormCollection form)
        {
            var colorName = form["ColorName"];
            var sizeValue = form["SizeValue"];
            var _pro = db.Products.SingleOrDefault(s => s.ProductId == id);
            var ImageData = db.GetImageToCart(id).Single();
            if (_pro != null)
            {
                GetCart().Add_Product_Cart(_pro, ImageData.ImageData, colorName, sizeValue);
            }
            return RedirectToAction("ShowCart", "Cart");
        }
        public ActionResult Update_Cart_Quantity(FormCollection form)
        {
            Carts cart = Session["Cart"] as Carts;
            int id_pro = int.Parse(form["idPro"]);
            string id_color = form["idcolor"];
            string id_size = form["idsize"];
            int _quantity = int.Parse(form["cartQuantity"]);
            cart.Update_quantity(id_pro, id_color, id_size, _quantity);
            return RedirectToAction("Showcart", "Cart");
        }
        public ActionResult RemoveCart(int id, string ColorName, string SizeValue)
        {
            Carts cart = Session["Cart"] as Carts;
            cart.Remove_CartItem(id,ColorName,SizeValue);
            return RedirectToAction("Showcart", "Cart");
        }
        public ActionResult CheckOut_Success()
        {
            return View();
        }

        //public ActionResult CheckOut(FormCollection from)
        //{
        //    try
        //    {
        //        var sessionMaNguoiDung = (Customer)Session["NguoiDung"];
        //        Carts cart = Session["Cart"] as Carts;
        //        Receipt hoaDon = new Receipt();
        //        if (Session["NguoiDung"] != null)
        //        {
        //            hoaDon.cu = sessionMaNguoiDung.MaNguoiDung;
        //            hoaDon.TenKhachHang = sessionMaNguoiDung.TenNguoiDung;
        //        }
        //        else
        //        {
        //            hoaDon.MaNguoiDung = null;
        //            hoaDon.TenKhachHang = from["TenKhachHang"];
        //        }
        //        hoaDon.TongSoLuong = Convert.ToInt32(cart.Total_quantity());
        //        hoaDon.TongTien = Convert.ToInt32(cart.Total_money());
        //        hoaDon.NgayMua = DateTime.Now;
        //        hoaDon.MaPhuongThuc = int.Parse(from["MaPhuongThuc"]);
        //        hoaDon.MaTrangThai = 1;
        //        db.HoaDons.Add(hoaDon);
        //        foreach (var item in cart.Items)
        //        {
        //            ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon();
        //            chiTietHoaDon.SoLuongSanPham = item._quantity;
        //            chiTietHoaDon.MaHoaDon = hoaDon.MaHoaDon;
        //            chiTietHoaDon.MaSanPham = item._product.MaSanPham;
        //            chiTietHoaDon.Gia = (item._product.DonGia * item._quantity);
        //            db.ChiTietHoaDons.Add(chiTietHoaDon);
        //        }
        //        db.SaveChanges();
        //        cart.ClearCart();
        //        return RedirectToAction("CheckOut_Success", "Cart");
        //    }
        //    catch
        //    {
        //        return Content("Lỗi thanh toán, làm phiền kiểm tra lại thông tin đơn hàng");

        //    }
        //}

    }
}