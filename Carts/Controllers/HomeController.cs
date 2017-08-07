﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Carts.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products select s).ToList();
                return View(result);
            }
        }
        public ActionResult Index2()
        {
            return Content("<html><body><h1>一段訊息</h1></body></html>");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Details(int id)
        {
            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                var result = (from s in db.Products
                              where s.Id == id
                              select s).FirstOrDefault();

                if (result == default(Models.Product))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View(result);
                }
            }
        }

        [HttpPost]  //限定使用POST
        [Authorize] //登入會員才可留言
        public ActionResult AddComment(int id, string Content)
        {
            //取得目前登入使用者Id
            var userId = HttpContext.User.Identity.GetUserId();

            var currentDateTime = DateTime.Now;

            var comment = new Carts.Models.ProductComment()
            {
                ProductId = id,
                Content = Content,
                UserId = userId,
                CreateDate = currentDateTime
            };

            using (Models.CartsEntities db = new Models.CartsEntities())
            {
                db.ProductComments.Add(comment);
                db.SaveChanges();
            }

            return RedirectToAction("Details", new { id = id });
        }
    }
}