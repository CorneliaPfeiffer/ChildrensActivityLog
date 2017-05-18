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
        //private readonly ChildrensActivityLogContext _context;
        public IActionResult Index()
        {
            string name = "";
           var result = _iRepo.GetAllChildren().ToList();
            foreach (var item in result)
            {
                name = item.FirstName;
            }
            //return Ok($"Die Kinder: {name} ");
           // return Ok($"{result} ");
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
}
