using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WarehouseManagementMVC.Models
{
    public class Warehouse
    {
        public int Id { get; set; }
        public ICollection<Item> Items { get; set; }
        public ICollection<Branch> Branches { get; set; }
    }
    public class Branch
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public ICollection<Item> Items { get; set; }
    }
   
    public class Item
    {
        public Item()
        {
            Categories = new HashSet<Category>();
        }
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public decimal Price { get; set; }

        [Range(0, 100), Display(Name = "Discount Percentage"), RegularExpression("([1-9][0-9]*)", ErrorMessage = "Enter only numeric number")]
        public double? DiscountPercentage { get; set; } = 0;

        public ICollection<Category> Categories { get; set; }
        public ICollection<Order> Orders { get; set; }

    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Item> Items { get; set; }
    }

    public class Order
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<Item> Items { get; set; }
    }

}