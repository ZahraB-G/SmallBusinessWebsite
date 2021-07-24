using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class InventoryProfileModel
    {
        public  int ItemId;
        
        public  string ItemName { get; set; }

       
        public  string ItemDescription { get; set; }
       
        public  string ItemManufactor { get; set; }
       
        public  int ItemQty { get; set; }
        
        public  double ItemRetailPrice { get; set; }
    }
}
