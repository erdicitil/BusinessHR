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
    public class PermissionTypesController : Controller
    {
        private readonly IPermissionTypeService permissionTypeService;

        public PermissionTypesController(IPermissionTypeService permissionTypeService)
        {
            this.permissionTypeService = permissionTypeService;
        }

        // GET: PermissionTypes
        public ActionResult Index()
        {
            var permissionType = Mapper.Map<IEnumerable<PermissionTypeViewModel>>(permissionTypeService.GetAll());
            return View(permissionType);
        }

        // GET: PermissionTypes/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PermissionTypeViewModel permissionType = Mapper.Map<PermissionTypeViewModel>(permissionTypeService.Get(id.Value));
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
        public ActionResult Create(PermissionTypeViewModel permissionType)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<PermissionType>(permissionType);
                permissionTypeService.Insert(entity);
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
            PermissionTypeViewModel permissionType = Mapper.Map<PermissionTypeViewModel>(permissionTypeService.Get(id.Value));
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
        public ActionResult Edit(PermissionTypeViewModel permissionType)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<PermissionType>(permissionType);
                permissionTypeService.Insert(entity);
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
            PermissionTypeViewModel permissionType = Mapper.Map<PermissionTypeViewModel>(permissionTypeService.Get(id.Value));
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
            permissionTypeService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
