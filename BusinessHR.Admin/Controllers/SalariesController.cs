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
    public class SalariesController : Controller
    {
        private readonly ISalaryService salaryService;

        public SalariesController(ISalaryService salaryService)
        {
            this.salaryService = salaryService;
        }

        // GET: Certificates
        public ActionResult Index()
        {
            var salary = Mapper.Map<IEnumerable<SalaryViewModel>>(salaryService.GetAll());
            return View(salary);
        }

        // GET: Certificates/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryViewModel salary = Mapper.Map<SalaryViewModel>(salaryService.Get(id.Value));
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // GET: Certificates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Certificates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalaryViewModel salary)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Salary>(salary);
                salaryService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(salary);
        }


        // GET: Certificates/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryViewModel salary = Mapper.Map<SalaryViewModel>(salaryService.Get(id.Value));
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalaryViewModel salary)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Salary>(salary);
                salaryService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(salary);
        }

        // GET: Certificates/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalaryViewModel salary = Mapper.Map<SalaryViewModel>(salaryService.Get(id.Value));
            if (salary == null)
            {
                return HttpNotFound();
            }
            return View(salary);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            salaryService.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
