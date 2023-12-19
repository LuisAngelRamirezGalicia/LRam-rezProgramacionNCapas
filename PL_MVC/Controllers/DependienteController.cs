using System;   
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class DependienteController : Controller
    {
        // GET: Dependiente
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

        [HttpGet]

        public ActionResult GetByNumeroEmpleado(string numeroEmpleado)
        {
            ML.Dependiente dependiente = new ML.Dependiente();



            ML.Result result = BL.Dependiente.DependienteGetByNumeroEmpleado(numeroEmpleado);
            ML.Empleado empleado = new ML.Empleado();
            empleado.NumeroEmpleado = numeroEmpleado;
            ML.Result resultEmpleado = BL.Empleado.EmpleadoGetById(empleado);
            
            empleado = (ML.Empleado)resultEmpleado.Object;
            dependiente.Empleado = new ML.Empleado();
            dependiente.Empleado = empleado;
            Session["Empleado"] = numeroEmpleado;
            Session["NombreEmpleado"] = empleado.Nombre;
            if (result.Correct)
            {
                dependiente.Dependientes = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }
            return View(dependiente);
        }
        [HttpGet]
        public ActionResult FormDependiente(int? idDependiente)
        {
            ML.Dependiente dependiente = new ML.Dependiente();

            ML.Result resultTipos = BL.DependienteTipo.DependienteTipoGetAll();
            dependiente.DependienteTipo = new ML.DependienteTipo();
            dependiente.DependienteTipo.DependienteTipos = resultTipos.Objects;
            dependiente.Empleado = new ML.Empleado();

            dependiente.Empleado.NumeroEmpleado = Session["Empleado"].ToString();
            //dependiente.Empleado.Nombre = Session["NombreEmpleado"].ToString();



            if (idDependiente == null)

            {
                
                ViewBag.Accion = "Agregar Usuario";
            }

            else

            {
                
                ML.Result result = BL.Dependiente.DependienteGetById(idDependiente.Value);

                if (result.Correct)
                {
                    dependiente = (ML.Dependiente)result.Object;
                    //ML.Dependiente dependiente1 = new ML.Dependiente();
                    //dependiente1.DependienteTipo = new ML.DependienteTipo();
                   // dependiente1 = (ML.Dependiente)result.Object;
                    //dependiente.DependienteTipo = new ML.DependienteTipo();
                    dependiente.DependienteTipo.DependienteTipos = resultTipos.Objects;
                   // dependiente.DependienteTipo.IdDependienteTipo = dependiente1.DependienteTipo.IdDependienteTipo;
                }
            }




                return View(dependiente);
        }

        [HttpPost]

        public ActionResult FormDependiente(ML.Dependiente dependiente)
        {

            ML.Result result = new ML.Result();

            if (dependiente.IdDependiente == 0)
            {
                result = BL.Dependiente.DependienteAdd(dependiente);
                ViewBag.Mensaje = result.ErrorMessage;

                return View("Modal");
            }
            else
            {
                result = BL.Dependiente.DependienteUpdate(dependiente);
                ViewBag.Mensaje = result.ErrorMessage;

                return View("Modal");


            }

        }

        public ActionResult Delete(int idDependiente)
        {
          
            
            ML.Result result = new ML.Result();
            result = BL.Dependiente.DependienteDelete(idDependiente); ViewBag.Mensaje = result.ErrorMessage;
            ViewBag.Mensaje = result.ErrorMessage;




            return View("Modal");
        }







        //    result = BL.Empleado.EmpleadoAdd(empleado);
        //    //return View(usuario);

        //    if (result.Correct)
        //    {
        //        ViewBag.Mensaje = result.ErrorMessage;
        //        //ViewBag.Mesaje = "prueba";
        //        return View("Modal");
        //    }
        //    else
        //    {
        //        return View("Modal");
        //    }
        //}
        //else
        //{
        //    if (fuImagen != null)
        //    {
        //        empleado.Foto = convertFileToByteArray(fuImagen);
        //    }


        //    result = BL.Empleado.EmpleadoUpdate(empleado);
        //    //return View(usuario);

        //    if (result.Correct)
        //    {
        //        ViewBag.Mensaje = result.ErrorMessage;
        //        //ViewBag.Mesaje = "prueba";
        //        return View("Modal");
        //    }
        //    else
        //    {
        //        return View("Modal");
        //    }
    }
}