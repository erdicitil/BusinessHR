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
    public class CompaniesController : Controller
    {
        private readonly ICityService cityService;
        private readonly ICountryService countryService;
        private readonly ICompanyService companyService;
        private readonly IRegionService regionService;
        public CompaniesController(ICompanyService companyService, ICityService cityService, ICountryService countryService, IRegionService regionService)
        {
            this.companyService = companyService;
            this.cityService = cityService;
            this.countryService = countryService;
            this.regionService = regionService;

        }
        // GET: Companies
        public ActionResult Index()
        {
            var companies = Mapper.Map<IEnumerable<CompanyViewModel>>(companyService.GetAll());
            return View(companies.ToList());
        }

        // GET: Companies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // GET: Companies/Create
        public ActionResult Create()
        {
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name");
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name");
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Company>(company);
                companyService.Insert(entity);
                return RedirectToAction("Index");
            }

            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", company.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.CountryId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.RegionId);
            return View(company);
        }

        // GET: Companies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));
            if (company == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", company.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.CountryId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.RegionId);
            return View(company);
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( CompanyViewModel company)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Company>(company);
                companyService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.CityId = new SelectList(cityService.GetAll(), "Id", "Name", company.CityId);
            ViewBag.CountryId = new SelectList(countryService.GetAll(), "Id", "Name", company.CountryId);
            ViewBag.RegionId = new SelectList(regionService.GetAll(), "Id", "Name", company.RegionId);
            return View(company);
        }

        // GET: Companies/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyViewModel company = Mapper.Map<CompanyViewModel>(companyService.Get(id.Value));
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            companyService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
