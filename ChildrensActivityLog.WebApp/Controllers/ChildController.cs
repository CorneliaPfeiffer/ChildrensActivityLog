using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChildrensActivityLog.Data.Repositories;
using ChildrensActivityLog.WebApp.Models;
using ChildrensActivityLog.WebApp.ViewModels;

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

           

            var child = new ChildDto()
            {
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };

            var childToCreate = AutoMapper.Mapper.Map<Domain.Child>(child);
            _iRepo.Add(childToCreate);
            if (!_iRepo.Save())
            {
                return StatusCode(500, "A problem happend while saving your request.");
            }
            var createdChild = AutoMapper.Mapper.Map<Models.ChildOnlyDto>(childToCreate);

            return Ok(createdChild);
        }
        //[HttpGet]
        //public IActionResult UpdateChild(int childId)
        //{
        //    var viewModel = new IndexViewModel();

        //    if (!ModelState.IsValid)
        //    { return BadRequest(ModelState); }
        //    ViewBag.firstname = viewModel.FirstName;

        //    var childFromDb = _iRepo.GetChildById(childId, false, false);
        //    var childNewData = new ChildDto()
        //    {
        //        FirstName = firstName,
        //        LastName = lastName,
        //        DateOfBirth = dateOfBirth
        //    };

        //    var childToCreate = AutoMapper.Mapper.Map<Domain.Child>(child);

        //    return PartialView("Index");
        //}

        //[HttpPut]
        public IActionResult UpdateChild(int childId, string firstName, string lastName, DateTime dateOfBirth)
        {
            if (!ModelState.IsValid)
            { return BadRequest(ModelState); }

            if(!_iRepo.ChildExists(childId))
            {
                return NotFound();
            }

            var childFromDb = _iRepo.GetChildById(childId, false, false);
            var childNewData = new ChildDto()
            {
                Id = childId,
                FirstName = firstName,
                LastName = lastName,
                DateOfBirth = dateOfBirth
            };
            AutoMapper.Mapper.Map(childNewData, childFromDb);
            if (!_iRepo.Save())
            {
                return StatusCode(500, "A problem happend while saving your request.");
            }

            return Ok("Updaterad");
        }

        //[HttpDelete]
        public IActionResult DeleteChild(int childId)
        {
            if(!_iRepo.ChildExists(childId))
            { return NotFound(); }
            var child = _iRepo.GetChildById(childId, false, false);
            _iRepo.DeleteChild(child);
            if (!_iRepo.Save())
            {
                return StatusCode(500, "A problem happend while saving your request.");
            }
          

            return Ok($"Barnet {child.FirstName} raderad.");
        }
    }
}