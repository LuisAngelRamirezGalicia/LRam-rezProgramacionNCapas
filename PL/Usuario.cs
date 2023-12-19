using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    public class Usuario
    {
        public static void Add()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());


            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el nombre o los nombres del usuario :");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido manterno del usuario :");
            usuario.ApellidoMaterno = Console.ReadLine();

            // Console.WriteLine("Ingrese la edad del usuario:");
            // usuario.Edad = byte.Parse(Console.ReadLine());




            ML.Result result = BL.Usuario.Add(usuario);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("El usuario fue ingresada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }


        }


        public static void AddProc()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());


            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el nombre o los nombres del usuario :");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido paterno del usuario:");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido manterno del usuario :");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese la edad del usuario:");
            // usuario.Edad = byte.Parse(Console.ReadLine());




            ML.Result result = BL.Usuario.AddProc(usuario);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("El usuario fue ingresada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }


        }


        public static void AddEF()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());


            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el user name del usuario  :");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre o los nombres del usuario :");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Apellido paterno del usuario :");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre o los nombres del usuario :");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Email del usuario:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese el password del usuario :");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo del usuario :");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono del usuario :");
            usuario.Telefono = Console.ReadLine();

            //   Console.WriteLine("Ingrese el telefono del usuario :");
            //   usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono celular del usuario :");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento del usuario:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese el curp del usuario");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("ingrese el rol del usuario");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());


            ML.Result result = BL.Usuario.AddEF(usuario);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("El usuario fue ingresada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }



        }




        //continual aquio 







        /*



        ML.Result result = BL.Usuario.AddEF(usuario);

        if (result.Correct) //result.Correct
        {
            Console.WriteLine("El usuario fue ingresada correctamente");
        }
        else
        {
            Console.WriteLine("Ocurrió .." + result.ErrorMessage);
        }
        */

        //}





        public static void Update()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());


            ML.Usuario usuario = new ML.Usuario();

            Console.WriteLine("Ingrese el id usuario para actualizar  :");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            Console.WriteLine("Ingrese el user name del usuario  :");
            usuario.UserName = Console.ReadLine();

            Console.WriteLine("Ingrese el nombre o los nombres del usuario :");
            usuario.Nombre = Console.ReadLine();

            Console.WriteLine("Ingrese el Apellido paterno del usuario :");
            usuario.ApellidoPaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el apellido materno del usuario :");
            usuario.ApellidoMaterno = Console.ReadLine();

            Console.WriteLine("Ingrese el Email del usuario:");
            usuario.Email = Console.ReadLine();

            Console.WriteLine("Ingrese el password del usuario :");
            usuario.Password = Console.ReadLine();

            Console.WriteLine("Ingrese el sexo del usuario :");
            usuario.Sexo = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono del usuario :");
            usuario.Telefono = Console.ReadLine();

            //  Console.WriteLine("Ingrese el telefono del usuario :");
            //  usuario.Telefono = Console.ReadLine();

            Console.WriteLine("Ingrese el telefono celular del usuario :");
            usuario.Celular = Console.ReadLine();

            Console.WriteLine("Ingrese la fecha de nacimiento del usuario:");
            usuario.FechaNacimiento = Console.ReadLine();

            Console.WriteLine("Ingrese el curp del usuario");
            usuario.CURP = Console.ReadLine();

            Console.WriteLine("ingrese el rol del usuario");
            usuario.Rol = new ML.Rol();
            usuario.Rol.IdRol = byte.Parse(Console.ReadLine());



            //ML.Result result = BL.Usuario.Update(usuario);
            ML.Result result = BL.Usuario.UpdateEF(usuario);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("EL Usuario fue Actualizada  correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }


        }

        public static void Delete()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());


            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el id del usuario del usuario para borrar:");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());





            ML.Result result = BL.Usuario.DeleteEF(usuario);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("El usuario fue borrada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }


        }
        //detele ef


        //getall

        public static void GetAll()
        {

            //ML.Usuario usuario = new ML.Usuario();
            //Console.WriteLine("Ingrese el id del usuario del usuario para Mostrar:");
            // usuario.ID = byte.Parse(Console.ReadLine());
            ML.Usuario  usuario1 = new ML.Usuario();

            ML.Result result = BL.Usuario.GetAllEF(usuario1);

            if (result.Correct)
            {
                foreach (ML.Usuario usuario in result.Objects)
                {
                    Console.WriteLine("********************************************");

                    Console.WriteLine("El ID de el usuario es: " + usuario.IdUsuario);
                    Console.WriteLine("El USERNAME de el usuario es: " + usuario.UserName);
                    Console.WriteLine("Los nombres de los usuarios son " + usuario.Nombre);
                    Console.WriteLine("El apellido paterno es" + usuario.ApellidoPaterno);
                    Console.WriteLine("EL Apellido Materno es" + usuario.ApellidoMaterno);
                    Console.WriteLine("El Email de el usuario es: " + usuario.Email);
                    Console.WriteLine("El password de el usuario es: " + usuario.Password);
                    Console.WriteLine("El sexo de el usuario es: " + usuario.Sexo);
                    Console.WriteLine("El Telefono de el usuario es: " + usuario.Telefono);
                    Console.WriteLine("El celular de el usuario es: " + usuario.Celular);
                    Console.WriteLine("la fecha de nacimiento  de el usuario es: " + usuario.FechaNacimiento);
                    Console.WriteLine("El curp de el usuario es: " + usuario.CURP);
                    Console.WriteLine("EL Rol del usuario es :" + usuario.Rol.IdRol);
                    Console.WriteLine("EL nombre del rol  del usuario es :" + usuario.Rol.NombreRol);
                    // Console.WriteLine("");


                    // Console.WriteLine("La edad del usuario es" + usuario.Edad);

                }



            }
        }


        public static void GetAllRol()
        {

            //ML.Usuario usuario = new ML.Usuario();
            //Console.WriteLine("Ingrese el id del usuario del usuario para Mostrar:");
            // usuario.ID = byte.Parse(Console.ReadLine());

            ML.Result result = BL.Rol.GetAllEF();

            if (result.Correct)
            {
                foreach (ML.Rol rol in result.Objects)
                {
                    Console.WriteLine("********************************************");


                    Console.WriteLine("EL Rol del usuario es :" + rol.IdRol);
                    Console.WriteLine("EL nombre del rol  del usuario es :" + rol.NombreRol);
                    // Console.WriteLine("");


                    // Console.WriteLine("La edad del usuario es" + usuario.Edad);

                }



            }
        }


        public static void GetByID()


        {

            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el id del usuario del usuario para Mostrar:");
            usuario.IdUsuario = byte.Parse(Console.ReadLine());

            ML.Result result = BL.Usuario.GetByIDEF(usuario);
            Console.WriteLine("Ingreso al metodo get by id");

            if (result.Correct)
            {
                // foreach (ML.Usuario usuario2 in result.Objects)
                // {
                ML.Usuario usuario2 = (ML.Usuario)result.Object;
                // usuario = result.Objects.Add(usuario); 
                ///usuario2 = result;
                //
                //  usuario2 = result.Object;

                Console.WriteLine("********************************************");
                Console.WriteLine("El ID de el usuario es: " + usuario.IdUsuario);
                Console.WriteLine("El USERNAME de el usuario es: " + usuario2.UserName);
                Console.WriteLine("Los nombres de los usuarios son " + usuario2.Nombre);
                Console.WriteLine("El apellido paterno es" + usuario2.ApellidoPaterno);
                Console.WriteLine("EL Apellido Materno es" + usuario2.ApellidoMaterno);
                Console.WriteLine("El Email de el usuario es: " + usuario2.Email);
                Console.WriteLine("El password de el usuario es: " + usuario2.Password);
                Console.WriteLine("El sexo de el usuario es: " + usuario2.Sexo);
                Console.WriteLine("El Telefono de el usuario es: " + usuario2.Telefono);
                Console.WriteLine("El celular de el usuario es: " + usuario2.Celular);
                Console.WriteLine("la fecha de nacimiento  de el usuario es: " + usuario2.FechaNacimiento);
                Console.WriteLine("El curp de el usuario es: " + usuario2.CURP);
                Console.WriteLine("EL Rol del usuario es :" + usuario2.Rol.IdRol);
                Console.WriteLine("EL nombre del rol del usuario es :" + usuario2.Rol.NombreRol);
                // Console.WriteLine("La edad del usuario es" + usuario2.Edad);
                // }

                //}
                //*/
            }
            else
            { Console.WriteLine(result.Correct); }
        }
        //getbyid


        /*
         * 
         * public static void Delete()
        {
            // Console.WriteLine("Ingrese el ID del usuario :");
            //usuario.ID = byte.Parse(Console.ReadLine());


            ML.Usuario usuario = new ML.Usuario();
            Console.WriteLine("Ingrese el id del usuario del usuario para borrar:");
            usuario.ID = byte.Parse(Console.ReadLine());





            ML.Result result = BL.Usuario.Delete (usuario);

            if (result.Correct) //result.Correct
            {
                Console.WriteLine("El usuario fue borrada correctamente");
            }
            else
            {
                Console.WriteLine("Ocurrió .." + result.ErrorMessage);
            }


        }
         
         */
        //METODOS DE LA EMPRESA

        



    }
}
