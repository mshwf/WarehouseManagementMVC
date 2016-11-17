using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WarehouseManagementMVC.DAL;
using WarehouseManagementMVC.ViewModels;
using WarehouseManagementMVC.Models;
using PagedList;


namespace WarehouseManagementMVC.Controllers
{
    public class WarehouseController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Warehouse
        public ActionResult Index(string sort, string search, int? page)
        {
            var warhouse = new WarehouseData();
            var items = db.Items.Include(c => c.Categories);
            warhouse.Branches = db.Branches;
            ViewBag.Search = search;
            switch (sort)
            {
                case "q_asc":
                    items = items.OrderBy(i => i.Quantity);
                    ViewBag.Sort = "q_desc";
                    break;
                case "q_desc":
                    items = items.OrderByDescending(i => i.Quantity);
                    ViewBag.Sort = "q_asc";
                    break;
                default:
                    items = items.OrderBy(i => i.Quantity);
                    ViewBag.Sort = "q_desc";
                    break;
            }

            if (!string.IsNullOrEmpty(search))
            {
                items = items.Where(i => i.Name.ToLower().Contains(search.ToLower()));
                ViewBag.Search = search;
            }
            int pageNumber = (page ?? 1);
            warhouse.Items = items.ToPagedList(pageNumber,5);

            ViewBag.ItemsPaged = warhouse.Items;
            
            return View(warhouse);
        }

        // GET: Warehouse/Details/5
        public ActionResult Details(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ////Warehouse warehouse = db.Warehouses.Find(id);
            //if (warehouse == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // GET: Warehouse/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Warehouse/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                //db.Warehouses.Add(warehouse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(warehouse);
        }

        // GET: Warehouse/Edit/5
        public ActionResult Edit(int? id)
        {
            //if (id == null)
            //{
            //    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            //}
            ////Warehouse warehouse = db.Warehouses.Find(id);
            //if (warehouse == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Warehouse/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id")] Warehouse warehouse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(warehouse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(warehouse);
        }

        // GET: Warehouse/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Warehouse warehouse = db.Warehouses.Find(id);
            //if (warehouse == null)
            //{
            //    return HttpNotFound();
            //}
            return View();
        }

        // POST: Warehouse/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Warehouse warehouse = db.Warehouses.Find(id);
            //db.Warehouses.Remove(warehouse);
            //db.SaveChanges();
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
