using System;
using System.Collections.Generic;
using System.Text;
using ChildrensActivityLog.Domain;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ChildrensActivityLog.Data.Repositories
{
    public class ChildrensAcitivityLogRepository : IChildrensAcitivityLogRepository
    {
        private ChildrensActivityLogContext _context = new ChildrensActivityLogContext();
        //public ChildrensAcitivityLogRepository(ChildrensActivityLogContext context)
        //{
        //    _context = context;
        //}

        public void Add(Child child)
        {
            _context.Children.Add(child);
            _context.SaveChanges();
        }

        public void Add(PlayEvent playEvent)
        {
            _context.PlayEvents.Add(playEvent);
            _context.SaveChanges();
        }

        public void Add(SleepingPeriod sleepingPeriod)
        {
            _context.SleepingPeriods.Add(sleepingPeriod);
            _context.SaveChanges();
        }

        public void ClearAll()
        {           
            _context.Database.ExecuteSqlCommand("DELETE FROM SleepingPeriods");
            _context.Database.ExecuteSqlCommand("DELETE FROM ChildrensPlayEvents");
            _context.Database.ExecuteSqlCommand("DELETE FROM PlayEvents");
            _context.Database.ExecuteSqlCommand("DELETE FROM Children");
            _context.SaveChanges();
        }

        public int CountChildren()
        {
        int i = 0;
            return i;
        }

        public int CountPlayEvents()
        {
            int i = 0;
            return i;
        }

        public IEnumerable<Child> GetAllChildren()
        {
            return _context.Children.OrderBy(c => c.FirstName).ToList();
        }

        public IEnumerable<PlayEvent> GetAllPlayEvents()
        {
            return _context.PlayEvents.ToList();
        }

        public IEnumerable<SleepingPeriod> GetAllsleepingPeriodsByChildId()
        {
            return _context.SleepingPeriods.ToList();
        }

        public Child GetChildById(int id)
        {            
                return _context.Children.FirstOrDefault(c => c.Id == id);
        }

        public Child GetChildById(int id, bool includePlayEvents, bool includeSleepingPeriods)
        {
            if (includeSleepingPeriods && includePlayEvents)
            {
                return _context.Children.Include(c => c.SleepingPeriods).Include(c => c.SleepingPeriods)
                        .Where(c => c.Id == id).FirstOrDefault();
            }
            if (includePlayEvents)
            { 
            return _context.Children.Include(c => c.ChildrensPlayEvents)
                    .Where(c => c.Id == id).FirstOrDefault();
            }
            if (includeSleepingPeriods)
            {
                return _context.Children.Include(c => c.SleepingPeriods)
                        .Where(c => c.Id == id).FirstOrDefault();
            }
            return _context.Children.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<PlayEvent> GetPlayEventsByChildId(int id)
        {
            return _context.PlayEvents.Include(p => p.ChildrensPlayEvents.Where(c => c.ChildId == id)).ToList();
                //.Where(p => p.ChildrensPlayEvents.ChildId == id);
        }

        public void Remove(Child child)
        {
            _context.Children.Remove(child);
            _context.SaveChanges();
        }

        public void Remove(PlayEvent playEvent)
        {
            _context.PlayEvents.Remove(playEvent);
            _context.SaveChanges();
        }

        public void Remove(SleepingPeriod sleepingPeriod)
        {
            _context.SleepingPeriods.Remove(sleepingPeriod);
            _context.SaveChanges();
        }

        public void Update(PlayEvent playEvent)
        {
            _context.PlayEvents.Update(playEvent);
            _context.SaveChanges();
        }

        public void Update(SleepingPeriod sleepingPeriod)
        {
            _context.SleepingPeriods.Update(sleepingPeriod);
            _context.SaveChanges();
        }
    }
}
