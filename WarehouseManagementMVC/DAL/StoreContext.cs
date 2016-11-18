using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WarehouseManagementMVC.Models;

namespace WarehouseManagementMVC.DAL
{
    public class StoreContext : DbContext
    {
        public StoreContext() : base("StoreConnection")
        {
        }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<WItem> WItems { get; set; }
        public DbSet<BItem> BItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
       
    }
}