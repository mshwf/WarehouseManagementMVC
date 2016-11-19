using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WarehouseManagementMVC.ViewModels
{
    public class AssignedCategories
    {
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public bool Assigned { get; set; }
    }
}