﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using site.Models;

using Newtonsoft.Json;

namespace site.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Message"] = "Scoring Engine";
            return View();
        }

        public IActionResult Injects()
        {
            ViewData["Message"] = "Injects";

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About Packer Systems";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult LogServer()
        {
            ViewData["Message"] = "Log Server";
            return View();
        }

        public JsonResult Checks()
        {
            using (StreamReader r = new StreamReader("wwwroot/js/current.json"))
            {
                string json = r.ReadToEnd();
                List<Check> checks = JsonConvert.DeserializeObject<List<Check>>(json);
                //return list as Json
                return Json(checks);
            }
        }

        public JsonResult InjectList()
        {
            using (StreamReader r = new StreamReader("wwwroot/js/injects.json"))
            {
                string json = r.ReadToEnd();
                List<Inject> injects = JsonConvert.DeserializeObject<List<Inject>>(json);
                //return list as Json
                return Json(injects);
            }
        }
    }
}
