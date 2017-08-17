using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Control_cuentas_maestro.seguridad
{
    public static class SessionPersister
    {


        public static bool activo
        {
            get
            {
                if (HttpContext.Current == null)
                    return false;
                var sessionVar = HttpContext.Current.Session["activo"];
                if (Convert.ToBoolean(sessionVar) == false)
                    return false;
                return true;
            }
            set
            {
                HttpContext.Current.Session["activo"] = value;
            }
        }
        public static string id_persona
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session["persona_id"];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session["persona_id"] = value;
            }
        }
        public static string id_curriculum
        {
            get
            {
                if (HttpContext.Current == null)
                    return string.Empty;
                var sessionVar = HttpContext.Current.Session["curriculum_id"];
                if (sessionVar != null)
                    return sessionVar as string;
                return null;
            }
            set
            {
                HttpContext.Current.Session["curriculum_id"] = value;
            }
        }
    }
}