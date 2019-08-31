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
    public class PositionsController : Controller
    {
        private readonly IPositionService positionService;
        private readonly IDepartmentService departmentService;

        public PositionsController(IPositionService positionService, IDepartmentService departmentService)
        {
            this.positionService = positionService;
            this.departmentService = departmentService;
        }


        // GET: Positions
        public ActionResult Index()
        {
            var position = Mapper.Map<IEnumerable<PositionViewModel>>(positionService.GetAll());
            return View(position);
        }

        // GET: Positions/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = Mapper.Map<PositionViewModel>(positionService.Get(id.Value));
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // GET: Positions/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name");
            return View();
        }

        // POST: Positions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PositionViewModel position)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Position>(position);
                positionService.Insert(entity);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", position.DepartmentId);
            return View(position);
        }

        // GET: Positions/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = Mapper.Map<PositionViewModel>(positionService.Get(id.Value));
            if (position == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", position.DepartmentId);
            return View(position);
        }

        // POST: Positions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PositionViewModel position)
        {
            if (ModelState.IsValid)
            {
                var entity = Mapper.Map<Position>(position);
                positionService.Update(entity);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentId = new SelectList(departmentService.GetAll(), "Id", "Name", position.DepartmentId);
            return View(position);
        }

        // GET: Positions/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PositionViewModel position = Mapper.Map<PositionViewModel>(positionService.Get(id.Value));
            if (position == null)
            {
                return HttpNotFound();
            }
            return View(position);
        }

        // POST: Positions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            positionService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
