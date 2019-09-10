using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
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
    public class EmployeesController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;
        private readonly ICertificateService certificateService;
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        private readonly IPositionService positionService;
        private readonly IRegionService regionService;
        

        public EmployeesController(IEmployeeService employeeService, IDepartmentService departmentService, ICertificateService certificateService, ICityService cityService, ICountryService countryService, IPositionService positionService, IRegionService regionService)
        {
            this.employeeService = employeeService;
            this.departmentService = departmentService;
            this.certificateService = certificateService;
            this.cityService = cityService;
            this.countryService = countryService;
            this.positionService = positionService;
            this.regionService = regionService;
            


        }

        // GET: Employees
        public ActionResult Index()
        {
            var employee = Mapper.Map<IEnumerable<EmployeeViewModel>>(employeeService.GetAll());
            return View(employee);
        }
        [HttpPost]
        public ActionResult GetCities(Guid countryId)
        {
            var cities = Mapper.Map<IEnumerable<CityViewModel>>(cityService.GetAllByCountryId(countryId));
            return Json(cities);
        }
        [HttpPost]
        public ActionResult GetRegions(Guid cityId)
        {
            var region = Mapper.Map<IEnumerable<RegionViewModel>>(regionService.GetAllByCityId(cityId));
            return Json(region);
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
            ViewBag.CityId = new SelectList(cityService.GetAllByCountryId(Guid.NewGuid()), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name");
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name");
            ViewBag.RegionId = new SelectList(regionService.GetAllByCityId(Guid.NewGuid()), "Id", "Name");

            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(EmployeeViewModel employee, HttpPostedFileBase upload)
        {

            if (ModelState.IsValid)
            {
               
                try
                {
                    employee.Photo = UploadFile(upload);
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;
                    return View(employee);

                }
                var entity = Mapper.Map<Employee>(employee);
                employeeService.Insert(entity);
                return RedirectToAction("Index");
            }



            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", employee.CertificateId);
            ViewBag.CityId = new SelectList(cityService.GetAllByCountryId(employee.CountryId ?? Guid.NewGuid()), "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(regionService.GetAllByCityId(employee.CityId ?? Guid.NewGuid()), "Id", "Name", employee.RegionId);

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
            ViewBag.CityId = new SelectList(cityService.GetAllByCountryId(employee.CountryId ?? Guid.NewGuid()), "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(regionService.GetAllByCityId(employee.CityId ?? Guid.NewGuid()), "Id", "Name", employee.RegionId);

            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(EmployeeViewModel employee, HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    if (upload != null && upload.ContentLength > 0)
                    {
                        // yüklenen dosyanın adını entity'deki alana ata
                        employee.Photo = UploadFile(upload);
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Error = ex.Message;

                    return View(employee);
                }
                var entity = Mapper.Map<Employee>(employee);
                employeeService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CertificateId = new SelectList(certificateService.GetAll(), "Id", "Name", employee.CertificateId);
            ViewBag.CityId = new SelectList(cityService.GetAllByCountryId(employee.CountryId ?? Guid.NewGuid()), "Id", "Name", employee.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", employee.CountryId);
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", employee.DepartmentId);
            ViewBag.PositionId = new SelectList(positionService.GetAll(), "Id", "Name", employee.PositionId);
            ViewBag.RegionId = new SelectList(regionService.GetAllByCityId(employee.CityId ?? Guid.NewGuid()), "Id", "Name", employee.RegionId);

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

        public string UploadFile(HttpPostedFileBase upload)
        {
            //yüklenmek istenen dosya var mı?

            if (upload != null && upload.ContentLength > 0)
            {
                //dosyanın uzantısını kontrol et.
                var extension = Path.GetExtension(upload.FileName).ToLower();
                if (extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".png")
                {
                    //uzantı doğruysa dosyanın yükleneceği Uploads dizini var mı kontrol et.
                    if (Directory.Exists(Server.MapPath("~/Uploads/")))
                    {
                        //dosya adındaki geçersiz karakterleri düzelt
                        string fileName = upload.FileName.ToLower();
                        fileName = fileName.Replace("İ", "i");
                        fileName = fileName.Replace("Ş", "s");
                        fileName = fileName.Replace("ı", "i");
                        fileName = fileName.Replace("(", "");
                        fileName = fileName.Replace(")", "");
                        fileName = fileName.Replace(" ", "-");
                        fileName = fileName.Replace(",", "");
                        fileName = fileName.Replace("ö", "o");
                        fileName = fileName.Replace("ü", "u");
                        fileName = fileName.Replace("`", "");
                        fileName = fileName.Replace("Ğ", "g");
                        fileName = fileName.Replace("ğ", "g");

                        //aynı isimde dosya olabilir diye dosya adının önüne zaman pulu ekliyoruz.
                        fileName = DateTime.Now.Ticks.ToString() + fileName;
                        //dosyayı Uploads dizinine yükle
                        upload.SaveAs(Path.Combine(Server.MapPath("~/Uploads/"), fileName));
                        //yüklenen dosyanın adını geri döndür.
                        return fileName;
                    }
                    else
                    {
                        throw new Exception("Uploads dizini mevcut değil");
                    }

                }
                else
                {
                    throw new Exception("Dosya uzantısı .jpg,.gif ya da .png olmalıdır.");
                }
            }
            return null;
        }
    }
}
