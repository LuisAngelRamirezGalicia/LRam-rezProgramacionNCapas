﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Rol
    {

        /* public class Semestre
         {
             public byte IdSemestre { get; set; } //propiedad
             public string Nombre { get; set; }
         }
         //public Rol() 
         //*/
        public byte? IdRol { get; set; }
        public string NombreRol { get; set; }

        public List<object> Roles { get; set; }

        //}
    }
}
