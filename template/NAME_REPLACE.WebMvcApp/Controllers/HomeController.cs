using IOC.FW.Core.Abstraction.Business;
using NAME_REPLACE.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NAME_REPLACE.WebMvcApp.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private readonly IBaseBusiness<Sample> _sampleBusiness;

        public HomeController(IBaseBusiness<Sample> sampleBusiness)
        {
            _sampleBusiness = sampleBusiness;
        }

        public JsonResult Index()
        {
            var all = _sampleBusiness.SelectAll();
            return Json(all, JsonRequestBehavior.AllowGet);
        }

    }
}
