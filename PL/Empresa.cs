using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Empresa
    {
        public static void EmpresaAdd()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());
            /*   @IdEmpresa int,
   @Nombre varchar(50),
   @Telefono varchar(50),
   @Email varchar(254),
   @DireccionWeb varchar(100)*/

            ML.Empresa empresa = new ML.Empresa();

         //   Console.WriteLine("Ingrese el Id de la empresa:");
         //   empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre de la empresa");
            empresa.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Telefono de la empresa");
            empresa.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el Email de la empresa");
            empresa.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la direccion web  de la empresa");
            empresa.DireccionWeb = Console.ReadLine();

            ML.Result result = BL.Empresa.EmpresaAddLINQ(empresa);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("la empresa fue ingresada  correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }



        }

        public static void EmpresaUpdate()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());
            /*   @IdEmpresa int,
   @Nombre varchar(50),
   @Telefono varchar(50),
   @Email varchar(254),
   @DireccionWeb varchar(100)*/

            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Ingrese el Id de la empresa a actualizar:");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el nombre de la empresa a actualizar");
            empresa.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Telefono de la empresa a actualizar");
            empresa.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el Email de la empresa a actualizar");
            empresa.Email = Console.ReadLine();

            Console.WriteLine("Ingrese la direccion web  de la empresa a actualizar");
            empresa.DireccionWeb = Console.ReadLine();

            ML.Result result = BL.Empresa.EmpresaUpdateLINQ(empresa);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("la empresa fue actualizada  correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }



        }

        public static void EmpresaDelete()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());
            /*   @IdEmpresa int,
   @Nombre varchar(50),
   @Telefono varchar(50),
   @Email varchar(254),
   @DireccionWeb varchar(100)*/

            ML.Empresa empresa = new ML.Empresa();

            Console.WriteLine("Ingrese el Id de la empresa a borrar:");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            

            ML.Result result = BL.Empresa.EmpresaDeleteLINQ(empresa);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("la empresa fue borrada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }



        }

        public static void EmpresaGetAll()
        {

            //ML.Usuario usuario = new ML.Usuario();
            //Console.WriteLine("Ingrese el id del usuario del usuario para Mostrar:");
            // usuario.ID = byte.Parse(Console.ReadLine());

            ML.Result result = BL.Empresa.EmpresaGetAllLINQ();

            if (result.Correct)
            {
                foreach (ML.Empresa empresa in result.Objects)
                {
                    Console.WriteLine("********************************************");

                    Console.WriteLine("El ID de la empresa es:  " + empresa.IdEmpresa);
                    Console.WriteLine("el nombre de la empresa es: " + empresa.Nombre);
                    Console.WriteLine("el Telefono de la empresa es: "+ empresa.Telefono);
                    Console.WriteLine("el Email de la empresa es: "+empresa.Email);
                    Console.WriteLine("la Direccion web de la empresa es: "+empresa.DireccionWeb);
                    // Console.WriteLine("");


                    // Console.WriteLine("La edad del usuario es" + usuario.Edad);

                }



            }
        }

        public static void EmpresaGetById()


        {

            ML.Empresa empresa= new ML.Empresa();
            Console.WriteLine("Ingrese el id de la empresa para Mostrar:");
            empresa.IdEmpresa = int.Parse(Console.ReadLine());

            ML.Result result = BL.Empresa.EmpresaGetByIdLINQ(empresa);
           // Console.WriteLine("Ingreso al metodo get by id");

            if (result.Correct)
            {
                // foreach (ML.Usuario usuario2 in result.Objects)
                // {
                ML.Empresa empresa2 = (ML.Empresa)result.Object;
                // usuario = result.Objects.Add(usuario); 
                ///usuario2 = result;
                //
                //  usuario2 = result.Object;

                Console.WriteLine("********************************************");

                Console.WriteLine("El ID de la empresa es:  " + empresa2.IdEmpresa);
                Console.WriteLine("el nombre de la empresa es: " + empresa2.Nombre);
                Console.WriteLine("el Telefono de la empresa es: " + empresa2.Telefono);
                Console.WriteLine("el Email de la empresa es: " + empresa2.Email);
                Console.WriteLine("la Direccion web de la empresa es: " + empresa2.DireccionWeb);
                // Console.WriteLine("La edad del usuario es" + usuario2.Edad);
                // }

                //}
                //*/
            }
            else
            { Console.WriteLine(result.Correct); }
        }
        //getbyid

    }
}
