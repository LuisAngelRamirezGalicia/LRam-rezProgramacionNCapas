using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpleadoController : Controller
    {
        // GET: Empleado
      
            //el form pero de empleado
            [HttpGet]

            public ActionResult Form(string numeroEmpleado)
            {

                ML.Empleado empleado = new ML.Empleado();
            empleado.Empresa = new ML.Empresa();
            ML.Result resultEmpresa = BL.Empresa.EmpresaGetAll();
            empleado.Empresa.Empresas = resultEmpresa.Objects;

            if (numeroEmpleado == null)

                {
                empleado.esNuevo = true;
                    ViewBag.Accion = "Agregar Empresa";
                }

                else

                {
                empleado.esNuevo = false;
                //empresa.IdEmpresa = IdEmpresa;
                empleado.NumeroEmpleado = numeroEmpleado;
                //ML.Result result = BL.Empresa.EmpresaGetById(empresa);
                //me hace falta otro metodo
                  ML.Result result = BL.Empleado.EmpleadoGetById(empleado);

                if (result.Correct)
                {
                    empleado = (ML.Empleado)result.Object;
                    empleado.Empresa.Empresas = resultEmpresa.Objects;
                }

                //// usuario.Rol.Roles = resultRol.Objects;

                //BL.Usuario.UpdateLINQ(usuario);
                ViewBag.Accion = "Actualizar datos";



                }
                return View(empleado);
            }








            [HttpPost]


            public ActionResult Form(ML.Empleado empleado,HttpPostedFileBase fuImagen)

            {
                ML.Result result = new ML.Result();
            
               
                    /* if (fuImagen != null)
                     {
                         usuario.Imagen = convertFileToByteArray(fuImagen);
                     }*/


                    //se tiene que cachar el resultado del result 
                    if(empleado.esNuevo)
                    {

                        if (fuImagen != null)
                        {
                            empleado.Foto = convertFileToByteArray(fuImagen);
                        }


               // DepartamentoService.DepartamentoClient departamentoClient = new DepartamentoService.DepartamentoClient();
               // var result = departamentoClient.GetAll();

                        

                result = BL.Empleado.EmpleadoAdd(empleado);
                        //return View(usuario);

                        if (result.Correct)
                        {
                            ViewBag.Mensaje = result.ErrorMessage;
                            //ViewBag.Mesaje = "prueba";
                            return View("Modal");
                        }
                        else
                        {
                            return View("Modal");
                        }
                    }
                    else
            {
                        if (fuImagen != null)
                        {
                            empleado.Foto = convertFileToByteArray(fuImagen);
                        }


                result = BL.Empleado.EmpleadoUpdate(empleado);
                        //return View(usuario);

                        if (result.Correct)
                        {
                            ViewBag.Mensaje = result.ErrorMessage;
                            //ViewBag.Mesaje = "prueba";
                            return View("Modal");
                        }
                        else
                        {
                            return View("Modal");
                        }


                    }





            //else

            //{
            //    /*  if (fuImagen != null)
            //      {
            //          usuario.Imagen = convertFileToByteArray(fuImagen);
            //      }*/

            //    result = BL.Empresa.EmpresaUpdate(empresa);
            //    if (result.Correct)
            //    {
            //        ViewBag.Mensaje = result.ErrorMessage;
            //        return View("Modal");
            //    }
            //    else { return View(); }



            //}

        }

        [HttpGet]
        public ActionResult GetAll()
        {

            ML.Empleado empleado = new ML.Empleado();
            empleado.Empleados = new List<object>();
            ML.Result result = BL.Empleado.EmpleadoGetAll();
            if (result.Correct)
            {
                empleado.Empleados = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }

            ViewBag.Title = "Empresas";

            return View(empleado);

        }


        public ActionResult Delete(string numeroEmpleado)
        {
            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = numeroEmpleado;
            ML.Result result = new ML.Result();
            result = BL.Empleado.EmpleadoDelete(empleado);
            ViewBag.Mensaje = result.ErrorMessage;




            return View("Modal");
        }



        public byte[] convertFileToByteArray(HttpPostedFileBase fuImagen)
        {
            MemoryStream target = new MemoryStream(); ;
            fuImagen.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            return data;
        }
    }

}