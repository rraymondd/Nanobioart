//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Noralighting.com.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ProductId { get; set; }
        public string ItemCode { get; set; }
        public Nullable<int> ItemType { get; set; }
        public bool IsVisible { get; set; }
        public System.DateTime AddedDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string SpecSheet { get; set; }
        public string IESData { get; set; }
        public string INSSheet { get; set; }
        public string RelatedKeywords { get; set; }
        public string MetaKeywords { get; set; }
        public string MetaDescription { get; set; }
        public string ProductApplication { get; set; }
    }
}
