//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ShoeStore.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class DetailReceipt
    {
        public int DetailReceiptId { get; set; }
        public Nullable<int> quantityProduct { get; set; }
        public Nullable<int> Price { get; set; }
        public Nullable<int> ReceiptId { get; set; }
        public Nullable<int> ProductColorSizeId { get; set; }
        public string SizeProduct { get; set; }
        public string ColorProduct { get; set; }
    
        public virtual ProductColorSize ProductColorSize { get; set; }
        public virtual Receipt Receipt { get; set; }
    }
}
