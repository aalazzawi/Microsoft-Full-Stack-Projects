using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DailyBloger.Models;

namespace DailyBloger.Controllers
{
    // this controler has 5 method perform the following
    // return the home content for the user
    // return the description page of the app with a message
    // return the contact page of the app with a message
    // return the privacy page
    /* reduces the amount of work the web server performs to generate a response by setting 
       the parameters of the cash control using the resources class and interfaces */
    // finaly return an appropriate View template instade of a message 

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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
