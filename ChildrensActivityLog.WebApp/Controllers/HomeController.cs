using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChildrensActivityLog.Data.Repositories;
using ChildrensActivityLog.Data;

namespace ChildrensActivityLog.WebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IChildrensAcitivityLogRepository _iRepo;
        public HomeController(IChildrensAcitivityLogRepository iRepo)
        {
            _iRepo = iRepo;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ClearDb()
        {
            _iRepo.ClearAll();
            return Ok("All data raderad");
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
}
