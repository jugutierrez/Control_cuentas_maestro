using Control_cuentas_maestro.Models;

using Control_cuentas_maestro.seguridad;
using login.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Control_cuentas_maestro.Controllers
{
    public class loginController : Controller
    {
        // GET: login

            PersonaDBContext db = new PersonaDBContext();
        public ActionResult Index()
        {
            SessionPersister.activo = false;
            Session.Clear();
            return View();
        }
        public ActionResult modal_index()
        {
            SessionPersister.activo = false;
            Session.Clear();
            return PartialView("_index");
        }



        public ActionResult Login(personas personas)
        {
            modelo_cuentas cv1 = new modelo_cuentas();
            if (string.IsNullOrEmpty(personas.correo_electronico_persona) || string.IsNullOrEmpty(personas.clave_persona) || cv1.login(personas.correo_electronico_persona, personas.clave_persona) == null)
            {
        
              
                return Json(new { success = false, respuesta = new { aviso = "el rut no es valido" } }, JsonRequestBehavior.AllowGet);
            }

           // var k = db.Database.SqlQuery<datos_session>("select id_persona , id_curriculum from personas where correo_electronico_persona = {0}", personas.correo_electronico_persona).Single();


            SessionPersister.activo = true;
            SessionPersister.id_persona = "0";//k.id_persona.ToString();
            SessionPersister.id_curriculum = "0"; //k.id_curriculum.ToString();
           
      return Json(new { success = true, respuesta = "../menu/index" }, JsonRequestBehavior.AllowGet);
        }

        [CustomAuthorize]
        public ActionResult Logout()
        {
            SessionPersister.activo = false;
            Session.Clear();
            return View("index");
        }
    }
}