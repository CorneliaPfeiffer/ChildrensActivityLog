using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChildrensActivityLog.Data.Repositories;

namespace ChildrensActivityLog.WebApp.Controllers
{
    public class ChildController : Controller
    {
        private readonly IChildrensAcitivityLogRepository _iRepo;
        public ChildController(IChildrensAcitivityLogRepository iRepo)
        {
            _iRepo = iRepo;
        }
        [HttpGet]
        public IActionResult GetAllChildren()
        {
            var result = _iRepo.GetAllChildren();
            return new JsonResult(result);
        }
        [HttpGet]
        public IActionResult CountChildren()
        {
            var result = _iRepo.CountChildren();
            return new JsonResult(result);
        }

        [HttpPost]
        public IActionResult CreateChild(string firstName, string lastName, DateTime dateOfBirth )
        {
            if(!ModelState.IsValid)
            { return BadRequest(ModelState); }
            return View();
        }
    }
}