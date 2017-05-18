using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ChildrensActivityLog.Data.Repositories;
using ChildrensActivityLog.WebApp.Models;

namespace ChildrensActivityLog.WebApp.Controllers
{
    [Produces("application/json")]
    [Route("api/ChildrenApi")]
    public class ChildrenApiController : Controller
    {
        private readonly IChildrensAcitivityLogRepository _iRepo;
        public ChildrenApiController(IChildrensAcitivityLogRepository iRepo)
        {
            _iRepo = iRepo;
        }
        // GET: api/ChildrenApi
        [HttpGet]
        //public IEnumerable<Child> GetAllChildren()
        public IActionResult GetAllChildren()
        {            
            var childEntities = _iRepo.GetAllChildren();
            var result = AutoMapper.Mapper.Map<IEnumerable<ChildOnlyDto>>(childEntities);
            //var result = new List<ChildOnlyDto>();
            //foreach (var child in ChildEntities)
            //{
            //    result.Add(new ChildOnlyDto
            //    {
            //        Id = child.Id,
            //        DateOfBirth = child.DateOfBirth,
            //        FirstName = child.FirstName,
            //        LastName = child.LastName
            //    });
            //}
            return Ok(result);
        }

        // GET: api/ChildrenApi/5
        //[HttpGet("{id}", Name = "Get")]
        [HttpGet("{id}")]
        public IActionResult GetChildById(int id, bool includePlayEvents = false, bool includeSleepingPeriods = false)
        {
            var child = _iRepo.GetChildById(id, includePlayEvents, includeSleepingPeriods);
            if (child == null)
            {
                return NotFound();
            }
            if (includePlayEvents)
            {
                var childResult = AutoMapper.Mapper.Map<ChildDto>(child);
                return new JsonResult(childResult);
            }
                if (includeSleepingPeriods)
            {
                //var childResult = new ChildDto()
                //{
                //    Id = child.Id,
                //    DateOfBirth = child.DateOfBirth,
                //    FirstName = child.FirstName,
                //    LastName = child.LastName
                //};

                //foreach (var sPer in child.SleepingPeriods)
                //{
                // childResult.ChildrensPlayEvents.Add(
                //        new SleepingPeriodDto()
                //        {
                //            Id = sPer.Id,
                //            TypeOfSleepingPeriod = sPer.TypeOfSleepingPeriod as TypeOfSleepingPeriods,
                //            From = sPer.From,
                //            To = sPer.To

                //        });
                //}
                var childResult = AutoMapper.Mapper.Map<ChildDto>(child);
                return new JsonResult(childResult);
            }
            else { 
            var childOnlyResult = AutoMapper.Mapper.Map<ChildOnlyDto>(child);
            return new JsonResult(childOnlyResult);
            }
        }

        //[HttpPost("{id}")]
        //public IActionResult CreateChild(int id)
        //{
        //    if ()

        //        return;
        //}

        // POST: api/ChildrenApi
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ChildrenApi/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
