using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace ML
{
    public class Usuario
    {
        public byte IdUsuario { get; set; }
       [Required(ErrorMessage = "El nick name es obligatorio")]
     [StringLength(500, ErrorMessage = "Demasiado largo")]
       /// [RegularExpression(@"^(?=.*[a-zA-Z])(?=.*[0-9])[a-zA-Z0-9]+$", ErrorMessage = "Solo se aceptan letras, numeros punto y guiones")]
        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Solo se aceptan letras, numeros punto y guiones")]


        [DisplayName("Nick name:")]
        public string UserName { get; set; }
[Required(ErrorMessage = "El Apellido Paterno es obligatorio")]
        [StringLength(500)]
       [DisplayName("Apellido Paterno:")]
        [RegularExpression(@"[A-Za-zÑñÁáÉéÍíÓóÚúÜü ]+$", ErrorMessage = "Solo se aceptan letras")]
        public string ApellidoPaterno { get; set; }
       [Required(ErrorMessage = "El Apellido Materno es obligatorio")]
        [StringLength(500)]
        [DisplayName("Apellido Materno:")]
        [RegularExpression(@"[A-Za-zÑñÁáÉéÍíÓóÚúÜü ]+$", ErrorMessage = "Solo se aceptan letras")]
        public string ApellidoMaterno { get; set; }
        [Required(ErrorMessage = "El correo electronico es obligatorio")]
        [StringLength(254, ErrorMessage = "Demasiado largo")]
        [DisplayName("Email:")]
       // [EmailAddress(ErrorMessage = "Ingrese un correo valido")]

        public string Email { get; set; }
        [Required(ErrorMessage = "El la contraseña es obligatoria")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "la contraseña debe de tener entre 8 y 50 caracteres")]
        // [PasswordPropertyText]
        [RegularExpression(@"^(?=.*\d)(?=.*[\u0021-\u002b\u003c-\u0040])(?=.*[A-Z])(?=.*[a-z])\S{8,50}$", ErrorMessage = "Contraseña no valida")]
        [DisplayName("Contraseña:")]



        public string Password { get; set; }
        [Required(ErrorMessage = "es obligatorio indicar su Sexo")]
        [StringLength(2, ErrorMessage = "Demasiado largo")]
      //  [RegularExpression(@"[MF]+$", ErrorMessage = "M o F")]
        public string Sexo { get; set; }
        [Required(ErrorMessage = "El telefono fijo es obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "el telefono debe tener 10 caracteres")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Solo se aceptan numeros")]
        public string Telefono { get; set; }
        [Required(ErrorMessage = "el  telefono celular es obligatorio")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "el celular debe terner 10 caracteres")]
        [RegularExpression(@"[0-9]+$", ErrorMessage = "Solo se aceptan numeros")]
        public string Celular { get; set; }
        [DisplayName("Fecha de Nacimiento:")]
        [Required(ErrorMessage = "la fecha de nacimiento es obligatoria")]
        public string FechaNacimiento { get; set; }//se cambio a string
    
        public string CURP { get; set; }
        //public object Rol { get; set; }

        [Required(ErrorMessage = "El Nombre es obligatorio")]
        [StringLength(500, ErrorMessage = "Demasiado largo")]
        [DisplayName("Nombre:")]
        [RegularExpression(@"[A-Za-zÑñÁáÉéÍíÓóÚúÜü ]+$", ErrorMessage = "Solo se aceptan letras")]
        public string Nombre { get; set; }

        //public virtual Rol Rol { get; set; }
       public bool Estatus { get; set; } 

        public ML.Rol Rol { get; set; }
        public ML.Direccion Direccion { get; set; }


        public List<object> Usuarios { get; set; }  

        



        public byte[] Imagen { get; set; }



    }
}
