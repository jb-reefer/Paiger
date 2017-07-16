﻿using System;
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

        [HttpGet("Article")]
        public IActionResult AddArticlePage()
        {
            return View("AddArticle");
        }

        [HttpPost]
        public IActionResult Article(ArticleModel article)
        {
            Console.WriteLine(article);
            return RedirectToAction("Index");
        }


        public IActionResult Publishers()
        {
            return View("Publishers");
        }

        [HttpGet("Publisher")]
        public IActionResult AddPublisherPage()
        {
            return View("AddPublisher");
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
