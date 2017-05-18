using Microsoft.AspNetCore.Mvc;
using ChildrensActivityLog.WebApp.Models;
using ChildrensActivityLog.Data.Repositories;
using System;

namespace ChildrensActivityLog.WebApp.Controllers
{
    public class SleepingPeriodController : Controller
    {
        private readonly IChildrensAcitivityLogRepository _iRepo;
        public SleepingPeriodController(IChildrensAcitivityLogRepository iRepo)
        {
            _iRepo = iRepo;
        }

        //[HttpPost("{childId}/sleepingPeriod")]
        [HttpPost]
        public IActionResult CreateSleepingPeriod(int childId, DateTime from, DateTime to)
        {
           
            //if(sleepingPeriod == null)
            //{
            //    return BadRequest();
            //}
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var child = _iRepo.GetChildById(childId, false, false);
            if (child == null)
            { return NotFound(); }

            var sleepingPeriod = new SleepingPeriodForCreationDto()
            {
                ChildId = childId,
                Child = child,
                From = from,
                To = to,
                TypeOfSleepingPeriod = SleepingPeriodForCreationDto.TypeOfSleepingPeriods.alright
            };

            var sleepingPeriodToCreate = AutoMapper.Mapper.Map<Domain.SleepingPeriod>(sleepingPeriod);
            _iRepo.AddSleepingPeriodByChildId(childId, sleepingPeriodToCreate);
            if (!_iRepo.Save())
            {
                return StatusCode(500, "A problem happend while saving your request.");
            }
            var createdSleepingPeriod = AutoMapper.Mapper.Map<Models.SleepingPeriodDto>(sleepingPeriodToCreate);

            return Ok(createdSleepingPeriod);
        }
    }
}