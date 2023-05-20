using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Models
{
    public class CartItem
    {
        public Product _product { get; set; }
        public int _quantity { get; set; }
        public byte[] _imgData { get; set; }
        public string ColorName { get; set; }
        public string SizeValue { get; set; }
    }
    public class Carts
    {
        List<CartItem> items = new List<CartItem>();
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        public void Add_Product_Cart(Product _pro, byte[] _imgData, string ColorName,string SizeValue,int _quan = 1)
        {
            var item = Items.FirstOrDefault(s => s._product.ProductId == _pro.ProductId);
            if (item == null)
            {
                   
                    items.Add(new CartItem { _product = _pro ,_imgData = _imgData, ColorName=ColorName,SizeValue=SizeValue, _quantity = _quan });
            }
            else
            {
                string checksize = Convert.ToString(item.SizeValue);
                string checkcolor = Convert.ToString(item.ColorName);
                if (SizeValue != checksize || ColorName != checkcolor)
                {
                    items.Add(new CartItem { _product = _pro, _imgData = _imgData, ColorName = ColorName, SizeValue = SizeValue, _quantity = _quan });
                }
                else
                {
                    item._quantity += _quan;
                }  
            }
        }
        public int Total_quantity()
        {
            return items.Sum(s => s._quantity);
        }
        public decimal Total_money()
        {
            var total = items.Sum(s => s._quantity * s._product.ProductPrice);
            if (Total_quantity() >= 3)
            {
                total = total - (total * 10 / 100);
            }
            return (decimal)total;
        }
        public void Update_quantity(int id, string id_color,string id_size, int _new_quan)
        {
            var item = items.Find(s => s._product.ProductId == id && s.ColorName == id_color && s.SizeValue == id_size);
            if (item != null )
            {
                item._quantity = _new_quan;
            }
        }
        public void Remove_CartItem(int id, string ColorName, string SizeValue)
        {
            items.RemoveAll(s => s._product.ProductId == id && s.SizeValue == SizeValue  && s.ColorName == ColorName);
        }
        public void ClearCart()
        {
            items.Clear(); // xóa giỏ hàng
        }
    }
}