using CRUDUsingADO.DAL;
using CRUDUsingADO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDUsingADO.Controllers
{
  
    public class EmployeeController : Controller
    {
        EmployeeDAL ed = new EmployeeDAL();
        // GET: EmployeeController
        public ActionResult Index()
        {
            var model = ed.GetEmployees();
            return View(model);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var model = ed.GetEmployeeById(id);
            return View(model);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int result = ed.AddEmployee(emp);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var model = ed.GetEmployeeById(id);
            return View(model);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Employee emp)
        {
            try
            {
                int result = ed.UpdateEmployee(emp);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var model = ed.GetEmployeeById(id);
            return View(model);
        }
   

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            try
            {
                int result = ed.DeleteEmployee(id);
                if (result == 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                    return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
