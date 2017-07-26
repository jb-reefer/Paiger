using System;
using System.Collections.Generic;
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


        public IActionResult Error()
        {
            return View();
        }
    }

    public class AdminController : Controller
    {

        [HttpGet("Article")]
        public IActionResult AddArticlePage()
        {
            return View("AddArticle");
        }

        [HttpPost]
        public IActionResult Article(Article article)
        {
            Console.WriteLine(article);
            return RedirectToAction("Articles");
        }

        public IActionResult Articles()
        {
            var articles = new List<Article>
            {
                new Article
                {
                    Publisher = "USA Today",
                    DatePublished = DateTime.Now,
                    Genre = { "Porn, Hats" },
                    Link = new Uri("https://buzzfeed.com"),
                    Title = "Porn hats for sale"
                },
                new Article
                {
                    Publisher = "USA Today",
                    DatePublished = DateTime.Now,
                    Genre = { "Porn, Hats" },
                    Link = new Uri("https://buzzfeed.com"),
                    Title = "Danielle Page: My vag"
                }
            };

            return View("Articles", articles);
        }


        public IActionResult Publishers()
        {
            var publishers = new List<Publisher>
            {
                new Publisher
                {
                    Name = "New York Times",
                    Homepage = new Uri("https://nytimes.com")
                },
                new Publisher
                {
                    Name = "USA Today",
                    Homepage = new Uri("https://usatoday.com")
                }
            };
            return View("Publishers", publishers);
        }

        [HttpGet("Publisher")]
        public IActionResult AddPublisherPage()
        {
            return View("AddPublisher");
        }

        [HttpPost]
        public IActionResult Publisher(Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(publisher.Name);
            }

            return new RedirectToActionResult("Publishers", "Home", null);
        }
    }
}
