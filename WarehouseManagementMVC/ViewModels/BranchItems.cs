using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagementMVC.ViewModels
{
    public class BranchItems
    {
        public int ItemId { get; set; }
        public string ItemName { get; set; }
        public bool Added { get; set; }
        public int Quantity { get; set; }
    }
}