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
    public class BranchController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Branch
        public ActionResult Index()
        {
            return View(db.Branches.ToList());
        }

        // GET: Branch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Include(b => b.Items).First(i => i.Id == id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        public ActionResult AddBranchItems(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Include(i => i.Items).Where(b => b.Id == id).Single();
            if (branch == null)
            {
                return HttpNotFound();
            }
            ViewBag.WrsItems = db.WItems.Where(i => i.Quantity > 0).ToList();
            return View(branch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBranchItems(int? id, string[] selectedItems, int[] qty)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var branchToUpdate = db.Branches.Include(i => i.Items).Where(d => d.Id == id).Single();
            UpdateBranchItems(branchToUpdate, selectedItems, qty);
            return RedirectToAction("Details", new { id = id });
        }

        private void UpdateBranchItems(Branch branchToUpdate, string[] selectedItems, int[] qty)
        {
            if (selectedItems == null)
            {
                return;
            }
            int j = 0;
            foreach (var item_id in selectedItems)
            {
                int itemId = int.Parse(item_id);
                var witem = db.WItems.Include(c => c.Categories).FirstOrDefault(w => w.Id == itemId);
                if (qty[j] > witem.Quantity)
                {
                    ModelState.AddModelError("", $"This amount not available, only {witem.Quantity}");
                }
                if (branchToUpdate.Items.Any(i => i.Name == witem.Name))
                {
                    var bitem = branchToUpdate.Items.Where(i => i.Name == witem.Name).FirstOrDefault();
                    bitem.Quantity += qty[j];
                    db.Entry(bitem).State = EntityState.Modified;
                }
                else
                {
                    branchToUpdate.Items.Add(new BItem { Name = witem.Name, Categories = witem.Categories, Price = witem.Price, Quantity = qty[j] });
                }
                witem.Quantity -= qty[j];
                db.Entry(witem).State = EntityState.Modified;
                db.SaveChanges();
                j++;
            }
        }

        // GET: Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Branch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Location")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Branches.Add(branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(branch);
        }

        // GET: Branch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Location")] Branch branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(branch);
        }

        // GET: Branch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Branch branch = db.Branches.Find(id);
            if (branch == null)
            {
                return HttpNotFound();
            }
            return View(branch);
        }

        // POST: Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Branch branch = db.Branches.Find(id);
            db.Branches.Remove(branch);
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
