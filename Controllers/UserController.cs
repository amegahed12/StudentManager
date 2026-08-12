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
            if (!ModelState.IsValid)
            {
                return View(u);
            }

            bool emailExists = db.Users.Any(usr => usr.Email == u.Email);
            if (emailExists)
            {
                ModelState.AddModelError("Email", "Email already exists!");
                return View(u);
            }

            db.Users.Add(u);
            db.SaveChanges();
            return RedirectToAction("Login");
        }

        ///
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User u)
        {

            ModelState.Remove("FirstName");
            ModelState.Remove("LastName");

            if (!ModelState.IsValid)
            {
                return View(u);
            }

            var userExist = db.Users.FirstOrDefault(usr => usr.Email == u.Email);

            if (userExist == null)
            {
                ModelState.AddModelError("Email", "Email Does not Exist!");
                return View(u);
            }

            if (userExist.Password != u.Password)
            {
                ModelState.AddModelError("Password", "Password Is Incorrect!");
                return View(u);
            }

            return RedirectToAction("GetAll", "Student");


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