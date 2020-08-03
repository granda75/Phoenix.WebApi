﻿using System.Web.Http.Cors;
using System.Web.Mvc;

namespace Phoenix.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";
            return View();
        }

        
    }
}
