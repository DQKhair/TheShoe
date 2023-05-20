using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoeStore.Entities
{
    public class CartProduct
    {
        //    public int Quantity = 1;
        //    public int ProductId { get; set; }
        //    public string ProductName { get; set; }
        //    public double? Price { get; set; }
        //    public byte[] Image { get; set; }

        //    public CartProduct(int quantity, int productId, string productName, byte[] image, double price =0)
        //    {
        //        Quantity = quantity;
        //        ProductId = productId;
        //        ProductName = productName;
        //        Price = price;
        //        Image = image;
        //    }

        //    public CartProduct()
        //    {
        //    }

        //    public static bool operator ==(CartProduct first,CartProduct second)
        //    {
        //        if (first.ProductId == second.ProductId) return true;
        //        return false;
        //    }
        //    public static bool operator !=(CartProduct first, CartProduct second)
        //    {
        //        return first == second;
        //    }

        //    public override bool Equals(object obj)
        //    {
        //        return obj is CartProduct product &&
        //               Quantity == product.Quantity &&
        //               ProductId == product.ProductId &&
        //               ProductName == product.ProductName &&
        //               Price == product.Price &&
        //               EqualityComparer<byte[]>.Default.Equals(Image, product.Image);
        //    }

        //    public override int GetHashCode()
        //    {
        //        int hashCode = 38517788;
        //        hashCode = hashCode * -1521134295 + Quantity.GetHashCode();
        //        hashCode = hashCode * -1521134295 + ProductId.GetHashCode();
        //        hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ProductName);
        //        hashCode = hashCode * -1521134295 + Price.GetHashCode();
        //        hashCode = hashCode * -1521134295 + EqualityComparer<byte[]>.Default.GetHashCode(Image);
        //        return hashCode;
        //    }
    }
}