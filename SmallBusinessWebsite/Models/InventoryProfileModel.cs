using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SmallBusinessWebsite.Models
{
    public class InventoryProfileModel
    {
       
        public int ItemId;
        [Required(ErrorMessage = "ItemName is required")]
        [MaxLength(50, ErrorMessage = "Item Name can be 50 character")]
        [Display(Name = "Item Name")]
        public string ItemName { get; set; }
  
        [MaxLength(50, ErrorMessage = "Item Description can not be larger than 50 characters")]
        [Display(Name = "Item Description")]
        public string ItemDescription { get; set; }
        [Display(Name = "Manufactor")]
        public string ItemManufactor { get; set; }
        [Display(Name = "Quantity of Item")]
        public int ItemQty { get; set; }
        [Display(Name = "RetailPrice")]
        public double ItemRetailPrice { get; set; }
    }
}