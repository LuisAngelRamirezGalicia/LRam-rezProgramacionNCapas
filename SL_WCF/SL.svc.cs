using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SL" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select SL.svc or SL.svc.cs at the Solution Explorer and start debugging.
    public class SL : ISL
    {
        public void DoWork()
        {
        }

        public string Prueba(string Nombre)
        {
            return "Hola" + Nombre;
        }


    }
}
