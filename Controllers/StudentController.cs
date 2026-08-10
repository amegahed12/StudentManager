using System;
using System.Collections.Generic;
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
    public class StudentController : Controller
    {
        private readonly AppDbContext db;
        private readonly ILogger<StudentController> _logger;

        public StudentController(ILogger<StudentController> logger, AppDbContext context)
        {
            _logger = logger;
            db = context;
        }

        public IActionResult GetAll()
        {
            // ViewData["Stds"] = db.Students.ToList();
            // var stds = db.Students.Include(s => s.Department).ToList();
            ViewBag.Stds = db.Students.Include(s => s.Department).ToList();
            return View();

        }

        public IActionResult Details(int id)
        {
            var std = db.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            return View(std);
        }

        public IActionResult Create()
        {
            //ViewBag.Depts = db.Departments.ToList();
            ViewData["Depts"] = db.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(Student s)
        {
            db.Students.Add(s);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }

        public IActionResult Edit(int id)
        {
            var std = db.Students.Include(s => s.Department).FirstOrDefault(s => s.Id == id);
            ViewBag.Depts = db.Departments.ToList();
            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student s)
        {
            db.Students.Update(s);
            db.SaveChanges();
            return RedirectToAction("GetAll");
        }



        public IActionResult Delete(int id)
        {
            var std = db.Students.Find(id);
            db.Students.Remove(std);
            db.SaveChanges();
            return RedirectToAction("GetAll");

        }


        // [HttpPost]
        // public IActionResult Edit(Student std)
        // {
        //     std.
        // }


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