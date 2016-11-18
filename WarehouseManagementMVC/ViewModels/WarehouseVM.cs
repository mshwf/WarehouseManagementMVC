using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WarehouseManagementMVC.Models;

namespace WarehouseManagementMVC.ViewModels
{
    public class WarehouseData
    {
        public IEnumerable<Item> Items { get; set; }
        public IEnumerable<Branch> Branches { get; set; }
    }
}