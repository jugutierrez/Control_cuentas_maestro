using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Control_cuentas_maestro.Models
{   
    public class modelo_cuentas
    { private List<personas> lista_cuentas = new List<personas>();
        PersonaDBContext db = new PersonaDBContext();

        public modelo_cuentas()
        {
          //lista_cuentas =  db.personas.ToList();
            lista_cuentas.Add(new personas { id_persona = 0, correo_electronico_persona = "123@123", clave_persona = "123123" });
            
        }
        public personas find(string user)
        {
            return lista_cuentas.Where(acc => acc.id_persona.Equals(Convert.ToInt32(user))).FirstOrDefault();
        }

        public personas login(string user, string pass)

        {
            return lista_cuentas.Where(acc => acc.correo_electronico_persona.Equals(user) && acc.clave_persona.Equals(pass)).FirstOrDefault();
        }
    
    }
}