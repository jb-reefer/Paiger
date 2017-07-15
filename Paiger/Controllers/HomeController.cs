using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Paiger.Models;

namespace Paiger.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult AddArticle()
        {
            return View("AddArticle");
        }

        public IActionResult AddPublisher()
        {
            return View("AddPublisher");
        }

        public IActionResult Publishers()
        {
            return View("Publishers");
        }


        [HttpPost]
        public IActionResult Publisher(PublisherDTO publisher)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(publisher.Name);
            }

            return new StatusCodeResult(200);
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
