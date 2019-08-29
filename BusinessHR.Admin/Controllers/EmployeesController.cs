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
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;
        private readonly ICertificateService certificateService;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        private readonly IPositionService positionService;
        private readonly IRegionService regionService;
        private readonly ISalaryService salaryService;

        public EmployeesController(IEmployeeService employeeService, IDepartmentService departmentService, ICertificateService certificateService, ICityService cityService, ICountryService countryService, IPositionService positionService, IRegionService regionService, ISalaryService salaryService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
            this.certificateService = certificateService;
            this.cityService = cityService;
            this.countryService = countryService;
            this.positionService = positionService;
            this.regionService = regionService;
            this.salaryService = salaryService;

            
        }

        // GET: Employees
        public ActionResult Index()
        {
            var employee = Mapper.Map<IEnumerable<EmployeeViewModel>>(employeeService.GetAll());
            return View(employee);
        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel employee = Mapper.Map<EmployeeViewModel>(employeeService.Get(id.Value));
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name");
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name");
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name");
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name");
            ViewBag.SalaryId = new SelectList(salaryService.GetAll(), "Id", "Durum");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Employee>(employee);
                employeeService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", employee.CertificateId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", employee.RegionId);
            ViewBag.SalaryId = new SelectList(salaryService.GetAll(), "Id", "Durum", employee.SalaryId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel employee = Mapper.Map<EmployeeViewModel>(employeeService.Get(id.Value));
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", employee.CertificateId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", employee.RegionId);
            ViewBag.SalaryId = new SelectList(salaryService.GetAll(), "Id", "Durum", employee.SalaryId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeViewModel employee)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Employee>(employee);
                employeeService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", employee.CertificateId);
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", employee.RegionId);
            ViewBag.SalaryId = new SelectList(salaryService.GetAll(), "Id", "Durum", employee.SalaryId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeViewModel employee = Mapper.Map<EmployeeViewModel>(employeeService.Get(id.Value));
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            employeeService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
