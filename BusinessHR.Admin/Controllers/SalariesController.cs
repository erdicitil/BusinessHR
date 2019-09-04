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
        private readonly IEmployeeService employeeService;

        public SalariesController(IEmployeeService employeeService, ISalaryService salaryService)
        {
            this.employeeService = employeeService;
            this.salaryService = salaryService;


        }
        // GET: Salaries
        public ActionResult Index()
        {
            var salaries = Mapper.Map<IEnumerable<SalaryViewModel>>(salaryService.GetAll());
            return View(salaries);
        }

        // GET: Salaries/Details/5
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

        // GET: Salaries/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(employeeService.GetAll(), "Id", "FirstName");
            return View();
        }

        // POST: Salaries/Create
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

            ViewBag.EmployeeId = new SelectList(employeeService.GetAll(), "Id", "FirstName", salary.EmployeeId);
            return View(salary);
        }

        // GET: Salaries/Edit/5
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
            ViewBag.EmployeeId = new SelectList(employeeService.GetAll(), "Id", "FirstName", salary.EmployeeId);
            return View(salary);
        }

        // POST: Salaries/Edit/5
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
            ViewBag.EmployeeId = new SelectList(employeeService.GetAll(), "Id", "FirstName", salary.EmployeeId);
            return View(salary);
        }

        // GET: Salaries/Delete/5
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

        // POST: Salaries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            salaryService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
