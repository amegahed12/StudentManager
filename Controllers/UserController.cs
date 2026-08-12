using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StudentManager.Models;

namespace StudentManager.Controllers
{
    // [Route("[controller]")]
    public class UserController : Controller
    {

        private readonly AppDbContext db;
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger, AppDbContext context)
        {
            _logger = logger;
            db = context;
        }

        /////////////////////////////////////


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User u)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(u);
        }

        ///
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {
            if (!ModelState.IsValid)
            {
                return View(u);
            }

            var userExist = db.Users.Find(u.Email);

            if (userExist == null)
            {
                return RedirectToAction("Register");
            }

            return RedirectToAction("Index", "Student/GetAll");


        }






        ////////////////////////////////////

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