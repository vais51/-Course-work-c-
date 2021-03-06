﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication5.Models;

namespace MvcApplication5.Controllers
{
    public class AdminController : Controller
    {
        private flowofdocumentEntities1 db = new flowofdocumentEntities1();

        //
        // GET: /Admin/

        public ViewResult Index(string search)
        {
            var employee = db.Employee.Include(e => e.Role);
            if (!String.IsNullOrEmpty(search))
            {
                employee = employee.Where(s => s.login.Contains(search));
            }
            return View(employee.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(string id = null)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            ViewBag.idRole = new SelectList(db.Role, "IdRole", "name");
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idRole = new SelectList(db.Role, "IdRole", "name", employee.idRole);
            return View(employee);
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(string id = null)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.idRole = new SelectList(db.Role, "IdRole", "name", employee.idRole);
            return View(employee);
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idRole = new SelectList(db.Role, "IdRole", "name", employee.idRole);
            return View(employee);
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(string id = null)
        {
            Employee employee = db.Employee.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Employee employee = db.Employee.Find(id);
            db.Employee.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}