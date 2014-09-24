using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace HoundsRace.Web.Models
{
    public class RaceEventRepository : IRaceEventsRepository
    {
        private List<RaceEvent> allRaceEvents;
        private XDocument raceEventData;
        private const string DATA_PATH = "~/App_Data/race.xml";

        public RaceEventRepository()
        {
            this.allRaceEvents = new List<RaceEvent>();
            this.raceEventData = XDocument.Load(HttpContext.Current.Server.MapPath(DATA_PATH));

            var raceEventsQuery = from raceEvent in raceEventData.Element("UpcomingEvents").Elements("RaceEvent")
                                  select new RaceEvent()
                                  {
                                      Id = int.Parse(raceEvent.Attribute("ID").Value),
                                      EventNumber = int.Parse(raceEvent.Attribute("EventNumber").Value),
                                      EventTime = DateTime.Parse(raceEvent.Attribute("EventTime").Value),
                                      FinishTime = DateTime.Parse(raceEvent.Attribute("FinishTime").Value),
                                      Distance = int.Parse(raceEvent.Attribute("Distance").Value),
                                      Name = raceEvent.Attribute("Name").Value,
                                      DogEntries = (from dog in raceEvent.Elements("Entry")
                                                    select new DogEntry()
                                                    {
                                                        Id = int.Parse(dog.Attribute("ID").Value),
                                                        Name = dog.Attribute("Name").Value,
                                                        OddsDecimal = decimal.Parse(dog.Attribute("OddsDecimal").Value),
                                                        RaceEventName = raceEvent.Attribute("Name").Value
                                                    }).ToList()
                                  };

            this.allRaceEvents = raceEventsQuery.ToList();
        }

        public IEnumerable<RaceEvent> GetAllRaceEvents()
        {
            return this.allRaceEvents;
        }

        public RaceEvent GetRaceEventById(int id)
        {
            return this.allRaceEvents.Find(e => e.Id == id);
        }
    }
}