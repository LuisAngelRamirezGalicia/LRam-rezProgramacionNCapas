using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //esta es la capa de presentacion

            Console.WriteLine("Capa de presentacion");
            Console.WriteLine("Ingrese 1 para agregar un usuario 2 para actualizarlo,3 para borrarlo,4 para mostrar toda la base de datos y 5 para consultar por id");
            byte opcion = byte.Parse(Console.ReadLine());

            //  ML.Usuario usuario = new ML.Usuario();
            //PL.usuario.Add(usuario);
            switch (opcion)
            {
                case 1:
                    PL.Empresa.EmpresaAdd();

                    break;

                case 2:
                    PL.Empresa.EmpresaUpdate();

                    break;

                case 3:
                    PL.Empresa.EmpresaDelete();
                    break;

                case 4:
                    PL.Usuario.GetAll();
                    break;

                case 5:
                    PL.Empresa.EmpresaGetById ();
                    break;

                case 6:
                    // PL.Usuario.AddProc();
                    PL.Usuario.AddEF();
                    break;

                case 7:
                    // PL.Usuario.AddProc();
                    PL.Usuario.GetAllRol();
                    break;
                case 8:
                //    PL.Estado.EstadoGetByIdPais();
                    break;

                default:
                    Console.WriteLine("esta opcion no es valida");
                    break;
            }
           // PL.Usuario.Add();

            Console.ReadKey();


        }
        
    }
}
