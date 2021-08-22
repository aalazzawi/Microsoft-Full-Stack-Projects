using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DailyBlogger.Controllers
{
    // this controler has 5 method perform the following
    // creat views to show the needed information 
    // desplay an error message if information is not found
    // desplay a certin file as a response
    // desplay a json file with the needed information as a response
    // redirect the user to new page 
    public class ExampleController : Controller
    {
        public IActionResult ShowMeAPage()
        {
            return View();
        }

        public IActionResult ShowMeAnError()
        {
            return NotFound();
        }

        public IActionResult GiveMeAFile()
        {
            return File("/mydoc.txt", "text/plain");
        }

        public IActionResult GiveMeSomeJson()
        {
            string jsondata = "{Name: John-Luc Picard, Rank: Captian, Starship: Enterprise}";

            return Json(jsondata);
        }


        public IActionResult TakeMeToGoogle()
        {
            return Redirect("https://google.com");
        }
    }
}
