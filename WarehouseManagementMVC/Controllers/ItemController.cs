using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WarehouseManagementMVC.DAL;
using WarehouseManagementMVC.Models;
using WarehouseManagementMVC.ViewModels;

namespace WarehouseManagementMVC.Controllers
{
    public class ItemController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Item
        public ActionResult Index()
        {
            return View(db.WItems.Where(s => !(s is BItem)));
        }

        // GET: Item/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WItem item = db.WItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            var item = new WItem();
            var categories = new List<Category>();
            PopulateCategories(item);
            return View();
        }

        private void PopulateCategories(WItem item)
        {
            var allCategories = db.Categories;
            var itemCategories = new HashSet<int>(item.Categories.Select(c => c.Id));
            var categoryData = new List<AssignedCategories>();
            foreach (var cat in allCategories)
            {
                categoryData.Add(new AssignedCategories
                {
                    CategoryID = cat.Id,
                    Name = cat.Name,
                    Assigned = itemCategories.Contains(cat.Id)
                });
            }
            ViewBag.Categories = categoryData;
        }

        // POST: Item/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Quantity,Price,DiscountPercentage")] WItem item)
        {
            if (ModelState.IsValid)
            {
                db.WItems.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(item);
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WItem item = db.WItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Quantity,Price,DiscountPercentage")] WItem item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(item);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            WItem item = db.WItems.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Item/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            WItem item = db.WItems.Find(id);
            db.WItems.Remove(item);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
