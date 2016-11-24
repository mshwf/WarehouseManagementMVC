using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WarehouseManagementMVC.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public ICollection<WItem> Items { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
    public class Branch
    {

        public int Id { get; set; }
        public string Location { get; set; }
        public ICollection<BItem> Items { get; set; }
        public Branch()
        {
            Items = new List<BItem>();
        }
    }
    public class WItem //Warehouse Item

    {
        public WItem()
        {
            Categories = new HashSet<Category>();
        }
        public int Id { get; set; }

        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
    [Table("BItems")]
    public class BItem : WItem //Branch Item
    {
        [Range(0, 100), Display(Name = "Discount Percentage"), RegularExpression(@"^(\d{0,2}(\.\d{1,2})?|100(\.00?)?)$", ErrorMessage = "Enter only numeric number")]
        public decimal DiscountPercentage { get; set; } = 0;
        public decimal NewPrice { get { return (Price - ((DiscountPercentage / 100) * Price)); } }
        public ICollection<Order> Orders { get; set; }

    }


    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<WItem> Items { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<WItem> Items { get; set; }
    }

}
