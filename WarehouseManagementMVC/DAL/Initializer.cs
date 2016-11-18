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
                new Branch { Location="Shubra", Items=new List<Item>()},
                new Branch { Location="Dokki", Items=new List<Item>()},
                new Branch { Location="6th October", Items=new List<Item>()},
                new Branch { Location="5th Settlement", Items=new List<Item>()},
                new Branch { Location="Al-Haram", Items=new List<Item>()},
                new Branch { Location="Mansoura", Items=new List<Item>()},
                new Branch { Location="Alexandria", Items=new List<Item>()}
            };
            branches.ForEach(b => context.Branches.Add(b));
            context.SaveChanges();
            var items = new List<Item>
            {
                new Item { Name="Lenovo E200", Price=1500, Quantity=200, DiscountPercentage=4, Categories=new List<Category>()},
                new Item { Name="Dell T101", Price=1200, Quantity=100, DiscountPercentage=0, Categories=new List<Category>()},
                new Item { Name="Galaxy S7", Price=7500, Quantity=300, DiscountPercentage=5, Categories=new List<Category>()},
                new Item { Name="Galaxy Note 5", Price=6000, Quantity=120, DiscountPercentage=20, Categories=new List<Category>()},
                new Item { Name="HTC Desire 860", Price=2800, Quantity=40, DiscountPercentage=0, Categories=new List<Category>()},
                new Item { Name="LG Nexus 6", Price=1500, Quantity=12, DiscountPercentage=2, Categories=new List<Category>()},
                new Item { Name="Nokia 200", Price=1500, Quantity=700, DiscountPercentage=0, Categories=new List<Category>()},
                new Item { Name="Nokia 105", Price=1500, Quantity=1005, DiscountPercentage=0, Categories=new List<Category>()},
                new Item { Name="Lumia 925", Price=1500, Quantity=660, DiscountPercentage=10, Categories=new List<Category>()},
                new Item { Name="Google Pixel", Price=1500, Quantity=120, DiscountPercentage=10, Categories=new List<Category>()},
                new Item { Name="Google Pixel XL", Price=1500, Quantity=100, DiscountPercentage=0, Categories=new List<Category>()},
                new Item { Name="iPhone 7", Price=1500, Quantity=100, DiscountPercentage=0, Categories=new List<Category>()},
                new Item { Name="iPhone 5", Price=1500, Quantity=14, DiscountPercentage=15, Categories=new List<Category>()},
                new Item { Name="Galaxy J5", Price=1500, Quantity=590, DiscountPercentage=8, Categories=new List<Category>()},
                new Item { Name="Asha 500", Price=1500, Quantity=500, DiscountPercentage=50, Categories=new List<Category>()},
                new Item { Name="Asha 250", Price=1500, Quantity=630, DiscountPercentage=20, Categories=new List<Category>()},
                new Item { Name="Nokia 320", Price=1500, Quantity=175, DiscountPercentage=8, Categories=new List<Category>()},
                new Item { Name="Lumia 825", Price=1500, Quantity=880, DiscountPercentage=25, Categories=new List<Category>()},
                new Item { Name="Huawei Mate 9 Pro", Price=1500, Quantity=15, DiscountPercentage=0, Categories=new List<Category>()},
                new Item { Name="iPad Air", Price=1500, Quantity=10, DiscountPercentage=3, Categories=new List<Category>()},
                new Item { Name="Galaxy Tab S2", Price=1500, Quantity=115, DiscountPercentage=2, Categories=new List<Category>()}
            };
            items.ForEach(i => context.Items.Add(i));
            context.SaveChanges();
            var categories = new List<Category>
            {
                new Category { Name="Android", Items=new List<Item>()},
                new Category { Name="iOS", Items=new List<Item>()},
                new Category { Name="Windows Phone", Items=new List<Item>()},
                new Category { Name="Nokia Asha", Items=new List<Item>()},
                new Category { Name="Economic", Items=new List<Item>()},
                new Category { Name="Flagships", Items=new List<Item>()},
                new Category { Name="Photogragy", Items=new List<Item>()},
                new Category { Name="Tablet", Items=new List<Item>()},
                new Category { Name="Phablet", Items=new List<Item>()},
                new Category { Name="Monochromatic Screen", Items=new List<Item>()}
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
                cat.Items.Add(context.Items.Single(i => i.Name == itemName));
            }
        }
    }
}