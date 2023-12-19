using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Empleado
    {
        //@NumeroEmpleado varchar(50),

        public string NumeroEmpleado { get; set; }
        //@RFC varchar(20),
        public string RFC { get; set; }
        //@Nombre varchar(50),
        public string Nombre { get; set; }
        //@ApellidoPaterno varchar(50),
        public string ApellidoPaterno { get; set; }
        //@ApellidoMaterno varchar(50),
        public string ApellidoMaterno { get; set; }
        //@Email varchar(50),
        public string Email { get; set; }
        //@Telefono varchar(20),
        public string Telefono { get; set; }
        //@FechaNacimiento date,
        public DateTime FechaNacimiento { get; set; }
        //@NSS varchar(20),
        public string NSS { get; set; }
        //@FechaIngreso date,
        public DateTime FechaIngreso { get; set; }
        //@Foto varbinary(MAx),
        public byte[] Foto { get; set; }
        //@idEmpresa int
        public ML.Empresa Empresa { get; set; }

        public bool esNuevo {  get; set; }


        public List<object> Empleados { get; set; }
    }
}
