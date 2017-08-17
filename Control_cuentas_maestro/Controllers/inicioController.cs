using Control_cuentas_maestro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control_cuentas_maestro.Controllers
{
    public class inicioController : Controller
    {
        PersonaDBContext db = new PersonaDBContext();
        // GET: inicio
        public ActionResult Index()
        {
   
            return View();
        }
    }
}