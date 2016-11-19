using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseManagementMVC.Models;

namespace WarehouseManagementMVC.ViewModels
{
    public class NewBranchItemVM
    {
        public IEnumerable<WItem> WrsItems { get; set; }
        public IEnumerable<BItem> BnchItems { get; set; }
    }
}