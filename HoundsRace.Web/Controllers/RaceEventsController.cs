using HoundsRace.Web.CustomFilters;
using HoundsRace.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HoundsRace.Web.Controllers
{
    public class RaceEventsController : Controller
    {

        private IRaceEventsRepository repository;

        public RaceEventsController()
            : this(new RaceEventRepository())
        {
        }

        public RaceEventsController(IRaceEventsRepository repository)
        {
            this.repository = repository;
        }

        public ActionResult List()
        {
            var raceEventsModel = this.repository.GetAllRaceEvents();

            return View(raceEventsModel);
        }

        [AjaxRequestsOnly]
        public ActionResult Details(int id)
        {
            var raceEventDetailedModel = this.repository.GetRaceEventById(id);

            if (raceEventDetailedModel == null)
            {
                RedirectToAction("List");
            }

            return PartialView("_RaceEventDetails", raceEventDetailedModel.DogEntries);
        }
    }
}