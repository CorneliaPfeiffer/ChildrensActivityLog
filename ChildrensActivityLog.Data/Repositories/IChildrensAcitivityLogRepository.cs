using ChildrensActivityLog.Domain;
using System.Collections.Generic;

namespace ChildrensActivityLog.Data.Repositories
{
    public interface IChildrensAcitivityLogRepository
    {
        IEnumerable<Child> GetAllChildren();
        IEnumerable<PlayEvent> GetAllPlayEvents();
        IEnumerable<SleepingPeriod> GetAllsleepingPeriodsByChildId();

        Child GetChildById(int id, bool includePlayEvents, bool includeSleepingPeriods);
        IEnumerable<PlayEvent> GetPlayEventsByChildId(int id);

        int CountChildren();
        int CountPlayEvents();

        void Add(Child child);
        void Add(PlayEvent playEvent);
        void AddSleepingPeriodByChildId(int childId, SleepingPeriod sleepingPeriod);

        void Update(PlayEvent playEvent);
        void Update(SleepingPeriod sleepingPeriod);

        void Remove(Child child);
        void Remove(PlayEvent playEvent);
        void Remove(SleepingPeriod sleepingPeriod);

        void ClearAll();

        bool Save();
    }
}
