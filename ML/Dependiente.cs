using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Dependiente
    {
        //        Create table Dependiente
        //(IdDependiente int primary key identity(1,1),
        public int IdDependiente { get; set; }
        //NumeroEmpleado VARCHAR(50) FOREIGN KEY REFERENCES Empleado(NumeroEmpleado),
        public ML.Empleado Empleado { get; set; }
        //Nombre VARCHAR(50),
        public string Nombre { get; set; }
        //ApellidoPaterno VARCHAR(50),
        public string ApellidoPaterno { get; set; }
        //ApellidoMaterno VARCHAR(50),
        public string ApellidoMaterno { get; set; }
        //FechaNacimiento date,
        public DateTime FechaNacimiento { get; set; }
        //EstadoCivil varchar(10),
        public string EstadoCivil { get; set; }
        //Genero varchar(2),
        public string Genero { get; set; }

        //Telefono varchar(20),
        public string Telefono { get; set; }
        //RFC varchar(20),
        public string RFC { get; set; }
        //IdDependienteTipo int FOREIGN KEY REFERENCES DependienteTipo(IdDependienteTipo)
        public ML.DependienteTipo DependienteTipo { get; set; }

        public List<object> Dependientes { get; set; }


        //)
    }
}
