using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BusinessHR.Data;
using BusinessHR.Model;

namespace BusinessHR.Admin.Controllers
{
    public class PermissionTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PermissionTypes
        public ActionResult Index()
        {
            return View(db.PermissionTypes.ToList());
        }

        // GET: PermissionTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionType permissionType = db.PermissionTypes.Find(id);
            if (permissionType == null)
            {
                return HttpNotFound();
            }
            return View(permissionType);
        }

        // GET: PermissionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PermissionTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] PermissionType permissionType)
        {
            if (ModelState.IsValid)
            {
                permissionType.Id = Guid.NewGuid();
                db.PermissionTypes.Add(permissionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(permissionType);
        }

        // GET: PermissionTypes/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionType permissionType = db.PermissionTypes.Find(id);
            if (permissionType == null)
            {
                return HttpNotFound();
            }
            return View(permissionType);
        }

        // POST: PermissionTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] PermissionType permissionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(permissionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(permissionType);
        }

        // GET: PermissionTypes/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionType permissionType = db.PermissionTypes.Find(id);
            if (permissionType == null)
            {
                return HttpNotFound();
            }
            return View(permissionType);
        }

        // POST: PermissionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            PermissionType permissionType = db.PermissionTypes.Find(id);
            db.PermissionTypes.Remove(permissionType);
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
