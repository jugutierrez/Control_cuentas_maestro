using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using Control_cuentas_maestro.Models;
namespace Control_cuentas_maestro.seguridad
{
    
    public class customPrincipal : IPrincipal
    {
        PersonaDBContext db = new PersonaDBContext();
        private personas cuentas;
  
        public customPrincipal(personas cuentas)
        {
            this.cuentas = cuentas;
            this.Identity = new GenericIdentity(cuentas.correo_electronico_persona);
        }
        public IIdentity Identity
        {
            get; set;
         
        }

    

         public bool IsInRole(string role)
        {
          var roles = role.Split(new char[] { ',' });
            //var rol = db.personas.Find(0);
            //string[] id = new string[1];
           // id[0] = rol.id_estado_persona.ToString();
            return roles.Any(r => this.cuentas.id_estado_persona.ToString().Contains(r));
        }
    }
}