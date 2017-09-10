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
            return PartialView("vistas_menu/_vista_panel_inicial");
        }
        [CustomAuthorize]
        public ActionResult vista2()
        {
            return PartialView("vistas_menu/_vista_bodegas");
        }
        [CustomAuthorize]
        public ActionResult vista3()
        {
            return PartialView("vistas_menu/_vista_estadisticas");
        }
        [CustomAuthorize]
        public ActionResult vista4()
            {
               return PartialView("vistas_menu/_vista_contacto");
    }
        [CustomAuthorize]
        public ActionResult vista_agregar_bodega()
        {
            return PartialView("mantenedor_bodegas/_vista_agregar_bodega");
        }
        [CustomAuthorize]
        public ActionResult vista_detalle_bodega()
        {
            return PartialView("mantenedor_bodegas/_vista_detalle_bodega");
        }
        public ActionResult denegado()
        {
            return View("denegado");
        }

    }
}