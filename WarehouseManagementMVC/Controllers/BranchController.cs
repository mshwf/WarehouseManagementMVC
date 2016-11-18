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
            ViewBag.ItemsInBranch = db.Items.ToList();
            return View(branch);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddBranchItems(int? id, string[] selectedItems, int qty)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var branchToUpdate = db.Branches.Include(i => i.Items).Where(d => d.Id == id).Single();
            UpdateBranchItems(branchToUpdate, selectedItems, qty);
            return RedirectToAction("Details", new { id = id });
        }

        private void UpdateBranchItems(Branch branchToUpdate, string[] selectedItems, int qty)
        {
            if (selectedItems == null)
            {
                branchToUpdate.Items = new List<Item>();
                return;
            }

            foreach (var item_id in selectedItems)
            {
                int itemId = int.Parse(item_id);
                var item = db.Items.Find(itemId);
                if (branchToUpdate.Items.Select(i => i.Id == itemId).SingleOrDefault())
                {
                    branchToUpdate.Items.Where(i => i.Id == itemId).Single().Quantity += qty;
                }
                else
                {
                    //branchToUpdate.Items.Add();db.Items.Where(i => i.Id == itemId).Single().Name
                    branchToUpdate.Items.Add(item);
                    db.SaveChanges();
                }
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
