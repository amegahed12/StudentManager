using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using StudentManager.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;

namespace StudentManager.Controllers
{
    // [Route("[controller]")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext db;
        private readonly ILogger<DepartmentController> _logger;

        public DepartmentController(ILogger<DepartmentController> logger, AppDbContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult GetAll()
        {
            var depts = db.Departments.Include(d => d.Students).ToList();
            return View(depts);
        }

        public IActionResult Details(int id)
        {
            var dept = db.Departments.Include(d => d.Students).FirstOrDefault(d => d.DeptId == id);

            return View(dept);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department d)
        {
            if (!ModelState.IsValid)
            {
                return View(d);
            }

            bool departmentExists = db.Departments.Any(dept => dept.Name == d.Name);
            if (departmentExists)
            {
                ModelState.AddModelError("Name", "Department already exists!");
                return View(d);
            }
            db.Departments.Add(d);
            db.SaveChanges();
            return RedirectToAction("GetAll");

        }

        public IActionResult Edit(int id)
        {
            var dept = db.Departments.Find(id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department d)
        {
            if (!ModelState.IsValid)
            {
                return View(d);
            }

            bool departmentExists = db.Departments.Any(dept => dept.Name == d.Name);
            if (departmentExists)
            {
                ModelState.AddModelError("Name", "Department already exists!");
                return View(d);
            }

            db.Departments.Update(d);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Delete(int id)
        {
            var dept = db.Departments.Include(d => d.Students).FirstOrDefault(d => d.DeptId == id);
            return View(dept);
        }

        [HttpPost]
        public IActionResult Delete(Department d)
        {
            var dept = db.Departments.Find(d.DeptId);
            db.Departments.Remove(dept);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }



        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}