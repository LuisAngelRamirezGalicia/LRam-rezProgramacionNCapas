using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Direccion
    {

        public int? IdDireccion { get; set; }

        [RegularExpression(@"[0-9A-Za-zÑñÁáÉéÍíÓóÚúÜü ]+$", ErrorMessage = "Solo se aceptan letras")]
        public string Calle { get; set; }
        [RegularExpression(@"[0-9A-Za-zÑñÁáÉéÍíÓóÚúÜü ]+$", ErrorMessage = "Solo se aceptan letras")]
        public string NumeroInterior { get; set; }
        [RegularExpression(@"[0-9A-Za-zÑñÁáÉéÍíÓóÚúÜü ]+$", ErrorMessage = "Solo se aceptan letras")]
        public string NumeroExterior { get; set; }

        public ML.Colonia Colonia { get; set; }

        public byte IdUsuario { get; set; }

        public List<object> Direcciones { get; set; }

    }
}
