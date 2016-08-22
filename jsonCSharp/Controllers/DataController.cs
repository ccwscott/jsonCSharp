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
            currentLocationData = Models.ServerData.getCurrentLocationData();
            return Json(currentLocationData, JsonRequestBehavior.AllowGet);
        }
	}
}