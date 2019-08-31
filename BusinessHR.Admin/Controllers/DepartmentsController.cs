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
    public class DepartmentsController : Controller
    {
        private readonly IDepartmentService departmentService;
        private readonly ICompanyService companyService;

        public DepartmentsController(IDepartmentService departmentService, ICompanyService companyService)
        {
            this.departmentService = departmentService;
            this.companyService = companyService;
        }

        // GET: Departments
        public ActionResult Index()
        {
            var department = Mapper.Map<IEnumerable<DeparmentViewModel>>(departmentService.GetAll());
            return View(department);
        }

        // GET: Departments/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeparmentViewModel department = Mapper.Map<DeparmentViewModel>(departmentService.Get(id.Value));
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DeparmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Department>(department);
                departmentService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", department.CompanyId);
            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeparmentViewModel department = Mapper.Map<DeparmentViewModel>(departmentService.Get(id.Value));
            if (department == null)
            {
                return HttpNotFound();
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", department.CompanyId);
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DeparmentViewModel department)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Department>(department);
                departmentService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CompanyId = new SelectList(companyService.GetAll(), "Id", "Name", department.CompanyId);
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DeparmentViewModel deparment = Mapper.Map<DeparmentViewModel>(departmentService.Get(id.Value));
            if (deparment == null)
            {
                return HttpNotFound();
            }
            return View(deparment);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            departmentService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
