using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSBC.Core.Models;

namespace CSBC.Core.Interfaces
{
    public interface ICsbcUow
    {
        // Save pending changes to the data store.
        void Commit();

        IScheduleGameRepository ScheduleGames { get; }
        IColorRepository Colors { get; }
        IHouseholdRepository Households { get; }
        // Repositories
        IPersonRepository People { get; }
        //IRepository<Room> Rooms { get; }
        //ISessionsRepository Sessions { get; }
        //IRepository<TimeSlot> TimeSlots { get; }
        //IRepository<Track> Tracks { get; }
        //IAttendanceRepository Attendance { get; }
    }
}
