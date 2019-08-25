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
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Certificate).Include(e => e.City).Include(e => e.Country).Include(e => e.Department).Include(e => e.Position).Include(e => e.Region).Include(e => e.Salary);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.CertificateId = new SelectList(db.Certificates, "Id", "Name");
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name");
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name");
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name");
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name");
            ViewBag.SalaryId = new SelectList(db.Salaries, "Id", "Durum");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Photo,Gender,DateOfBirth,IdentityNumber,Mobile,Nationality,Address,DepartmentId,PositionId,Title,CompanyWorkStartDate,CompanyWorkEndDate,SalaryId,CertificateId,CountryId,CityId,RegionId,WorkStatus,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.Id = Guid.NewGuid();
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CertificateId = new SelectList(db.Certificates, "Id", "Name", employee.CertificateId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", employee.RegionId);
            ViewBag.SalaryId = new SelectList(db.Salaries, "Id", "Durum", employee.SalaryId);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificateId = new SelectList(db.Certificates, "Id", "Name", employee.CertificateId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", employee.RegionId);
            ViewBag.SalaryId = new SelectList(db.Salaries, "Id", "Durum", employee.SalaryId);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Photo,Gender,DateOfBirth,IdentityNumber,Mobile,Nationality,Address,DepartmentId,PositionId,Title,CompanyWorkStartDate,CompanyWorkEndDate,SalaryId,CertificateId,CountryId,CityId,RegionId,WorkStatus,CreatedBy,CreatedAt,UpdatedBy,UpdatedAt,IsDeleted,DeletedBy,DeletedAt,IsActive,IpAddress,UserAgent,Location")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CertificateId = new SelectList(db.Certificates, "Id", "Name", employee.CertificateId);
            ViewBag.CityId = new SelectList(db.Cities, "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(db.Countries, "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(db.Departments, "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(db.Positions, "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(db.Regions, "Id", "Name", employee.RegionId);
            ViewBag.SalaryId = new SelectList(db.Salaries, "Id", "Durum", employee.SalaryId);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
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
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
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
