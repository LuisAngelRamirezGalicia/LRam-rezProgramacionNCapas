using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class ResutlColonia
    {


        public bool Correct { get; set; }
        public string ErrorMessage { get; set; }
        public object Object { get; set; }
        public List<object> Objects { get; set; }
        public Exception Ex { get; set; }

        public ML.Direccion Direccion { get; set; }
    }
}
