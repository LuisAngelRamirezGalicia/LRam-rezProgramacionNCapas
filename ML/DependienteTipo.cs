using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class DependienteTipo
    {
        //IdDependienteTipo int primary key identity(1,1),
        public int IdDependienteTipo { get; set; }
        //    Nombre varchar(20)
        public string Nombre { get; set; }

        public List<object> DependienteTipos { get; set; }


    }
}
