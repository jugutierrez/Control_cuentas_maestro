using Control_cuentas_maestro.seguridad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control_cuentas_maestro.Controllers
{
    public class menuController : Controller
    {
        [CustomAuthorize]
        public ActionResult Index()
        {
            return View();
        }
        [CustomAuthorize]
        public ActionResult vista1()
        {
            return PartialView("_vista1");
        }
        [CustomAuthorize]
        public ActionResult vista2()
        {
            return PartialView("_vista2");
        }
        [CustomAuthorize]
        public ActionResult vista3()
        {
            return PartialView("_vista3");
        }
        public ActionResult denegado()
        {
            return View("denegado");
        }

    }
}