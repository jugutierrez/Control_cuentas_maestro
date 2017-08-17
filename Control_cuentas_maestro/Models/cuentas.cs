using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Control_cuentas_maestro.Models
{
    public class cuentas
    {
        [Display(Name = "id_persona")]
        public int id_persona { get; set; }

        [Display(Name = "id_curriculum")]
        public int id_curriculum { get; set; }

        
    }

    public class PersonaDBContext : DbContext
    {
        public DbSet<personas> personas { get; set; }
     
    }


}