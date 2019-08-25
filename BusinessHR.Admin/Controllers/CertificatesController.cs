﻿using System;
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
    public class CertificatesController : Controller
    {
        private readonly ICertificateService certificateService;

        public CertificatesController(ICertificateService certificateService)
        {
            this.certificateService = certificateService;
        }

        // GET: Certificates
        public ActionResult Index()
        {
            var certificate = Mapper.Map<IEnumerable<CertificateViewModel>>(certificateService.GetAll());
            return View(certificate);
        }

        // GET: Certificates/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificateViewModel certificate = Mapper.Map<CertificateViewModel>(certificateService.Get(id.Value));
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
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
        public ActionResult Create( CertificateViewModel certificate)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Certificate>(certificate);
                certificateService.Insert(entity);
                return RedirectToAction("Index");
            }

            return View(certificate);
        }
    

        // GET: Certificates/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificateViewModel certificate = Mapper.Map<CertificateViewModel>(certificateService.Get(id.Value));
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }

        // POST: Certificates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CertificateViewModel certificate)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Certificate>(certificate);
                certificateService.Update(entity);
                return RedirectToAction("Index");
            }
            return View(certificate);
        }

        // GET: Certificates/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CertificateViewModel certificate = Mapper.Map<CertificateViewModel>(certificateService.Get(id.Value));
            if (certificate == null)
            {
                return HttpNotFound();
            }
            return View(certificate);
        }

        // POST: Certificates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            certificateService.Delete(id);
            return RedirectToAction("Index");
        }

       
    }
}
