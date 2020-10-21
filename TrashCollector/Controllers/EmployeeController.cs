using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrashCollector.Data;
using TrashCollector.Models;

namespace TrashCollector.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext db;
        public EmployeeController(ApplicationDbContext db)
        {
            this.db = db;
        }
        // GET: EmployeeController
        public ActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var employee = db.Employee.Where(c => c.IdentityUserId ==
            userId).SingleOrDefault();
            var customerList = db.Customer.Where(m => m.ZipCode == employee.ZipCode);
            return View(employee);
        }
            

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var employeeDetail = db.Employee.Find(id);
            return View(employeeDetail);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)//(IFormCollection collection)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                employee.IdentityUserId = userId;
                db.Employee.Add(employee);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var employeeEdit = db.Employee.Find(id);
            return View(employeeEdit);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)//(int id, IFormCollection collection)
        {
            try
            {
                db.Employee.Update(employee);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var employeeDelete = db.Employee.Find(id);
            return View(employeeDelete);
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Employee employee)
        {
            try
            {
                db.Employee.Remove(employee);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        public ActionResult ConfirmPickUp(int id)
        {
            var customer = db.Customer.Where(c => c.Id == id).FirstOrDefault();
            customer.ConfirmPickUp = true;
            customer.Balance += 10;
            db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
