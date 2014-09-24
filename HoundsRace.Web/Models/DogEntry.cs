using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HoundsRace.Web.Models
{
    public class DogEntry
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [DisplayName("Odds")]
        public decimal OddsDecimal { get; set; }

        public string RaceEventName { get; set; }
    }
}