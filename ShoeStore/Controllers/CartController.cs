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

        public ActionResult CheckOut(FormCollection from)
        {
            try
            {
                var sessionMaNguoiDung = (Customer)Session["CheckTaiKhoan"];
                Carts cart = Session["Cart"] as Carts;
                Receipt hoaDon = new Receipt();
                if (Session["CheckTaiKhoan"] != null)
                {
                    hoaDon.CustomerUsername = sessionMaNguoiDung.CustomerUsername;
                    hoaDon.CustomerName = sessionMaNguoiDung.CustomerName;
                }
                else
                {
                    hoaDon.CustomerUsername = null;
                    hoaDon.CustomerName = from["TenKhachHang"];
                }
                hoaDon.TotalQuantity = Convert.ToInt32(cart.Total_quantity());
                hoaDon.Total = Convert.ToInt32(cart.Total_money());
                hoaDon.dates = DateTime.Now;
                hoaDon.PaymentId = int.Parse(from["MaPhuongThuc"]);
                hoaDon.StatusId = 1;
                db.Receipts.Add(hoaDon);
                foreach (var item in cart.Items)
                {
                    DetailReceipt chiTietHoaDon = new DetailReceipt();
                    chiTietHoaDon.quantityProduct = item._quantity;
                    chiTietHoaDon.ReceiptId = hoaDon.ReceiptId;
                    chiTietHoaDon.ProductColorSizeId = item._product.ProductId;
                    chiTietHoaDon.Price = Convert.ToInt32((item._product.ProductPrice * item._quantity));
                    chiTietHoaDon.SizeProduct = item.SizeValue;
                    chiTietHoaDon.ColorProduct = item.ColorName;
                    db.DetailReceipts.Add(chiTietHoaDon);
                }
                db.SaveChanges();
                cart.ClearCart();
                return RedirectToAction("CheckOut_Success", "Cart");
            }
            catch
            {
                return Content("Lỗi thanh toán, làm phiền kiểm tra lại thông tin đơn hàng");

            }
        }

    }
}