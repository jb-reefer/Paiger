using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pager.Models;
using System.Linq;
using System.Configuration;

namespace Pager.Controllers
{
    public class AdminController : Controller
    {
        IPagerContext db { get; set; }
        IStorageService storageClient;

        public AdminController(IStorageService storageClient, IPagerContext ctx)
        {
            db = ctx;

            // TODO: Submit a bug report about the message on having this in the controller signature
            this.storageClient = storageClient;
        }

        [HttpGet("Article")]
        public IActionResult AddArticlePage()
        {
            return View("AddArticle");
        }

        [HttpPost]
        public IActionResult Article(Article article)
        {
            if (ModelState.IsValid)
            {
                db.Articles.Add(article);

                return StatusCode(200);
            }

            db.Articles.Add(article);


            return StatusCode(400);
        }

        public IActionResult Articles()
        {
            if (!db.Articles.Any())
            {
                var articles = new List<Article>();
                articles.Add(new Article
                {
                    Publisher = "USA Today",
                    DatePublished = DateTime.Now,
                    //Genre = { "Sex writing", "Hats" },
                    Link = new Uri("https://buzzfeed.com"),
                    Title = "Porn hats for sale"
                });
                articles.Add(new Article
                {
                    Publisher = "USA Today",
                    DatePublished = DateTime.Now,
                    //Genre = { "Sex writing", "Cats" },
                    Link = new Uri("https://buzzfeed.com"),
                    Title = "Danielle Page: My vag"
                });

                db.Articles.AddRange(articles);
            }


            return View("Articles", db.Articles);
        }


        public IActionResult Publishers()
        {
            //var publishers = new List<Publisher>
            //{
            //    new Publisher
            //    {
            //        Name = "New York Times",
            //        Homepage = new Uri("https://nytimes.com")
            //    },
            //    new Publisher
            //    {
            //        Name = "USA Today",
            //        Homepage = new Uri("https://usatoday.com")
            //    }
            //};
            return View("Publishers", db.Publishers);
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
                var iconName = publisher.Name + publisher.Icon.FileName.Substring(publisher.Icon.FileName.LastIndexOf('.'));

                var iconUri = storageClient.UploadStreamAs(publisher.Icon.OpenReadStream(), iconName);

                var publisherRecord = new Publisher
                {
                    Homepage = publisher.Homepage,
                    Name = publisher.Name,
                    IconUrl = iconUri
                };

                db.Publishers.Add(publisherRecord);

                return StatusCode(200);
            }

            // bitch and moan
            return StatusCode(401);
        }
    }
}
