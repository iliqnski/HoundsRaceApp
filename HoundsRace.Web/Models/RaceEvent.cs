using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoundsRace.Web.Models
{
    public class RaceEvent
    {
        public int Id { get; set; }

        [DisplayName("Race Number")]
        public int EventNumber { get; set; }

        [DisplayName("Start Time")]
        public DateTime EventTime { get; set; }

        [DisplayName("Finish Time")]
        public DateTime FinishTime { get; set; }

        public int Distance { get; set; }

        public string Name { get; set; }

        public IEnumerable<DogEntry> DogEntries { get; set; }
    }
}