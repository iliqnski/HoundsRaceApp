using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoundsRace.Web.Models
{
    public interface IRaceEventsRepository
    {
        IEnumerable<RaceEvent> GetAllRaceEvents();

        RaceEvent GetRaceEventById(int id);
    }
}