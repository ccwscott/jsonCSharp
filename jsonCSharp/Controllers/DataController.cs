using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jsonCSharp.Controllers
{
    public class DataController : Controller
    {

        //
        // GET: /Data/
        public ActionResult getPrices()
        {
            Models.Location currentLocationData = new Models.Location();
            currentLocationData.locationName = "Earth";
            currentLocationData.metalPrice = "15";
            currentLocationData.powerPrice = "53";
            currentLocationData.refugees = "15";
            currentLocationData.research = "1000";
            currentLocationData.waterPrice = "0";
            currentLocationData.airPrice = "0";
            currentLocationData.distance = 4000;
            currentLocationData.foodPrice = "4";
            currentLocationData.fuelPrice = "5";
            currentLocationData.weaponPrice = "50";
            return Json(currentLocationData, JsonRequestBehavior.AllowGet);
        }
	}
}