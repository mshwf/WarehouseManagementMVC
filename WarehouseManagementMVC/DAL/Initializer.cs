using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WarehouseManagementMVC.Models;

namespace WarehouseManagementMVC.DAL
{
    public class Initializer : DropCreateDatabaseAlways<StoreContext>
    {
        protected override void Seed(StoreContext context)
        {
            //bogus data

            var branches = new List<Branch>
            {
                new Branch { Location="Shubra", Items=new List<BItem>()},
                new Branch { Location="Dokki", Items=new List<BItem>()},
                new Branch { Location="6th October", Items=new List<BItem>()},
                new Branch { Location="5th Settlement", Items=new List<BItem>()},
                new Branch { Location="Al-Haram", Items=new List<BItem>()},
                new Branch { Location="Mansoura", Items=new List<BItem>()},
                new Branch { Location="Alexandria", Items=new List<BItem>()}
            };
            branches.ForEach(b => context.Branches.Add(b));
            context.SaveChanges();
            var items = new List<WItem>
            {
                new WItem { Name="Lenovo E200", Price=1500, Quantity=200, Categories=new List<Category>()},
                new WItem { Name="Dell T101", Price=1200, Quantity=100, Categories=new List<Category>()},
                new WItem { Name="Galaxy S7", Price=7500, Quantity=300, Categories=new List<Category>()},
                new WItem { Name="Galaxy Note 5", Price=6000, Quantity=120, Categories=new List<Category>()},
                new WItem { Name="HTC Desire 860", Price=2800, Quantity=40, Categories=new List<Category>()},
                new WItem { Name="LG Nexus 6", Price=1500, Quantity=12, Categories=new List<Category>()},
                new WItem { Name="Nokia 200", Price=1500, Quantity=700, Categories=new List<Category>()},
                new WItem { Name="Nokia 105", Price=275, Quantity=1005, Categories=new List<Category>()},
                new WItem { Name="Lumia 925", Price=1500, Quantity=660, Categories=new List<Category>()},
                new WItem { Name="Google Pixel", Price=1500, Quantity=120, Categories=new List<Category>()},
                new WItem { Name="Google Pixel XL", Price=1500, Quantity=100, Categories=new List<Category>()},
                new WItem { Name="iPhone 7", Price=1500, Quantity=100, Categories=new List<Category>()},
                new WItem { Name="iPhone 5", Price=1500, Quantity=14, Categories=new List<Category>()},
                new WItem { Name="Galaxy J5", Price=1500, Quantity=590, Categories=new List<Category>()},
                new WItem { Name="Asha 500", Price=1500, Quantity=500, Categories=new List<Category>()},
                new WItem { Name="Asha 250", Price=1500, Quantity=630, Categories=new List<Category>()},
                new WItem { Name="Nokia 320", Price=1500, Quantity=175, Categories=new List<Category>()},
                new WItem { Name="Lumia 825", Price=1500, Quantity=880, Categories=new List<Category>()},
                new WItem { Name="Huawei Mate 9 Pro", Price=1500, Quantity=15, Categories=new List<Category>()},
                new WItem { Name="iPad Air", Price=1500, Quantity=10, Categories=new List<Category>()},
                new WItem { Name="Galaxy Tab S2", Price=1500, Quantity=115, Categories=new List<Category>()}
            };
            items.ForEach(i => context.WItems.Add(i));
            context.SaveChanges();
            var categories = new List<Category>
            {
                new Category { Name="Android", Items=new List<WItem>()},
                new Category { Name="iOS", Items=new List<WItem>()},
                new Category { Name="Windows Phone", Items=new List<WItem>()},
                new Category { Name="Nokia Asha", Items=new List<WItem>()},
                new Category { Name="Economic", Items=new List<WItem>()},
                new Category { Name="Flagships", Items=new List<WItem>()},
                new Category { Name="Photogragy", Items=new List<WItem>()},
                new Category { Name="Tablet", Items=new List<WItem>()},
                new Category { Name="Phablet", Items=new List<WItem>()},
                new Category { Name="Monochromatic Screen", Items=new List<WItem>()}
            };
            categories.ForEach(c => context.Categories.Add(c));
            context.SaveChanges();

            AddCategories(context, "Lenovo E200", "Android");
            AddCategories(context, "Lenovo E200", "Economic");
            AddCategories(context, "Dell T101", "Economic");
            AddCategories(context, "Dell T101", "Android");
            AddCategories(context, "Galaxy S7", "Android");
            AddCategories(context, "Galaxy S7", "Flagships");
            AddCategories(context, "Galaxy S7", "Photogragy");
            AddCategories(context, "Galaxy Note 5", "Android");
            AddCategories(context, "Galaxy Note 5", "Photogragy");
            AddCategories(context, "Galaxy Note 5", "Flagships");
            AddCategories(context, "Galaxy Note 5", "Phablet");
            AddCategories(context, "HTC Desire 860", "Android");
            AddCategories(context, "HTC Desire 860", "Flagships");
            AddCategories(context, "LG Nexus 6", "Android");
            AddCategories(context, "LG Nexus 6", "Phablet");
            AddCategories(context, "LG Nexus 6", "Flagships");
            AddCategories(context, "LG Nexus 6", "Photogragy");
            AddCategories(context, "Nokia 200", "Monochromatic Screen");
            AddCategories(context, "Nokia 200", "Economic");
            AddCategories(context, "Nokia 105", "Monochromatic Screen");
            AddCategories(context, "Nokia 105", "Economic");
            AddCategories(context, "Lumia 925", "Windows Phone");
            AddCategories(context, "Lumia 925", "Flagships");
            AddCategories(context, "Lumia 925", "Photogragy");
            AddCategories(context, "Lumia 925", "Phablet");
            AddCategories(context, "Google Pixel", "Flagships");
            AddCategories(context, "Google Pixel", "Android");
            AddCategories(context, "Google Pixel", "Photogragy");
            AddCategories(context, "Google Pixel XL", "Phablet");
            AddCategories(context, "Google Pixel XL", "Android");
            AddCategories(context, "Google Pixel XL", "Photogragy");
            AddCategories(context, "Google Pixel XL", "Flagships");
            AddCategories(context, "iPhone 7", "iOS");
            AddCategories(context, "iPhone 7", "Flagships");
            AddCategories(context, "iPhone 7", "Photogragy");
            AddCategories(context, "iPhone 5", "iOS");
            AddCategories(context, "Galaxy J5", "Android");
            AddCategories(context, "Asha 500", "Economic");
            AddCategories(context, "Asha 500", "Nokia Asha");
            AddCategories(context, "Asha 250", "Nokia Asha");
            AddCategories(context, "Asha 250", "Economic");
            AddCategories(context, "Nokia 320", "Economic");
            AddCategories(context, "Nokia 320", "Monochromatic Screen");
            AddCategories(context, "Lumia 825", "Windows Phone");
            AddCategories(context, "Lumia 825", "Flagships");
            AddCategories(context, "Lumia 825", "Phablet");
            AddCategories(context, "Huawei Mate 9 Pro", "Android");
            AddCategories(context, "Huawei Mate 9 Pro", "Photogragy");
            AddCategories(context, "Huawei Mate 9 Pro", "Flagships");
            AddCategories(context, "iPad Air", "Tablet");
            AddCategories(context, "iPad Air", "iOS");
            AddCategories(context, "Galaxy Tab S2", "Android");
            AddCategories(context, "Galaxy Tab S2", "Economic");
            AddCategories(context, "Galaxy Tab S2", "Tablet");
        }

        void AddCategories(StoreContext context, string itemName, string categoryTitle)
        {
            var cat = context.Categories.SingleOrDefault(c => c.Name == categoryTitle);
            var itm = cat.Items.SingleOrDefault(i => i.Name == itemName);
            if (itm == null)
            {
                cat.Items.Add(context.WItems.Single(i => i.Name == itemName));
            }
        }
    }
}