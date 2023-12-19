using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empresa
    {
        /* @IdEmpresa int,
 @Nombre varchar(50),
 @Telefono varchar(50),
 @Email varchar(254),
 @DireccionWeb varchar(100)*/
        public Nullable<int> IdEmpresa { get; set; }  
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string DireccionWeb { get; set; }

        public string ErrorMessage { get; set; }

        public bool isValidExcel { get; set; }


        public List<object> Empresas { get; set; }


    }
}
