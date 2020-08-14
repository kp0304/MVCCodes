using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeDB.Models;

namespace EmployeeDB.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeContext db = new EmployeeContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.Department).Include(e => e.Employee1);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
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
            ViewBag.DepartmentNo = new SelectList(db.Departments, "DepartmentID", "Name");
            ViewBag.ReportingTo = new SelectList(db.Employees, "Number", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Number,Name,Salary,Commission,DateOfJoining,DateOfBirth,DepartmentNo,JobTitle,ReportingTo")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.DepartmentNo = new SelectList(db.Departments, "DepartmentID", "Name", employee.DepartmentNo);
            ViewBag.ReportingTo = new SelectList(db.Employees, "Number", "Name", employee.ReportingTo);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.DepartmentNo = new SelectList(db.Departments, "DepartmentID", "Name", employee.DepartmentNo);
            ViewBag.ReportingTo = new SelectList(db.Employees, "Number", "Name", employee.ReportingTo);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Number,Name,Salary,Commission,DateOfJoining,DateOfBirth,DepartmentNo,JobTitle,ReportingTo")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.DepartmentNo = new SelectList(db.Departments, "DepartmentID", "Name", employee.DepartmentNo);
            ViewBag.ReportingTo = new SelectList(db.Employees, "Number", "Name", employee.ReportingTo);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
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
        public ActionResult DeleteConfirmed(int id)
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

        public ActionResult EmployeesByDept()
        {
            ViewBag.Department = new SelectList(db.Departments,
                nameof(Department.DepartmentID), nameof(Department.Name));
            return View();
        }

        [HttpPost]
        public ActionResult EmployeesByDept(int department)
        {
            var employees = db.Employees.Where(e => e.DepartmentNo == department);
            ViewBag.Department = new SelectList(db.Departments,
                nameof(Department.DepartmentID), nameof(Department.Name));
            return View(employees);
        }
    }
}
