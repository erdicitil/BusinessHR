using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BusinessHR.Admin.Models;
using BusinessHR.Data;
using BusinessHR.Model;
using BusinessHR.Service;

namespace BusinessHR.Admin.Controllers
{
    [Authorize]
    public class PermissionsController : Controller
    {
        private readonly IPermissionService permissionService;
        private readonly IPermissionTypeService permissionTypeService;

        public PermissionsController(IPermissionService permissionService, IPermissionTypeService permissionTypeService)
        {
            this.permissionService = permissionService;
            this.permissionTypeService = permissionTypeService;
        }

        // GET: Permissions
        public ActionResult Index()
        {
            var permission = Mapper.Map<IEnumerable<PermissionViewModel>>(permissionService.GetAll());
            return View(permission);
        }

        // GET: Permissions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionViewModel permission = Mapper.Map<PermissionViewModel>(permissionService.Get(id.Value));
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // GET: Permissions/Create
        public ActionResult Create()
        {
            ViewBag.PermissionTypeId = new SelectList(permissionTypeService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Permissions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PermissionViewModel permission)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Permission>(permission);
                permissionService.Insert(entity);
                return RedirectToAction("Index");
            }
            ViewBag.PermissionTypeId = new SelectList(permissionTypeService.GetAll(), "Id", "Name", permission.PermissionTypeId);
            return View(permission);
        }

        // GET: Permissions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionViewModel permission = Mapper.Map<PermissionViewModel>(permissionService.Get(id.Value));
            if (permission == null)
            {
                return HttpNotFound();
            }
            ViewBag.PermissionTypeId = new SelectList(permissionTypeService.GetAll(), "Id", "Name", permission.PermissionTypeId);
            return View(permission);
        }

        // POST: Permissions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PermissionViewModel permission)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Permission>(permission);
                permissionService.Insert(entity);
                return RedirectToAction("Index");
            }
            ViewBag.PermissionTypeId = new SelectList(permissionTypeService.GetAll(), "Id", "Name", permission.PermissionTypeId);
            return View(permission);
        }

        // GET: Permissions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionViewModel permission = Mapper.Map<PermissionViewModel>(permissionService.Get(id.Value));
            if (permission == null)
            {
                return HttpNotFound();
            }
            return View(permission);
        }

        // POST: Permissions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            permissionService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
