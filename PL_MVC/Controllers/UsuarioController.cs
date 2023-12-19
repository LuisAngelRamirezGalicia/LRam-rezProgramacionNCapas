using ML;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{   //controlador del usuario 
    public class UsuarioController : Controller
    {
        // GET: Usuario
        // GET All es para obtener los registros de la base de datos 

        [HttpGet]
        public ActionResult GetAll()
        {   //crear la instancia del objeto
            ML.Usuario usuario = new ML.Usuario();
            // inicializar los valores que requiere el store procedure 
            usuario.Nombre = string.Empty;
            usuario.ApellidoMaterno = string.Empty;
            usuario.ApellidoPaterno = string.Empty;
            usuario.Rol = new ML.Rol();
            ML.Result resultRol = BL.Rol.GetAllEF();
            usuario.Rol.Roles = resultRol.Objects;
            usuario.Rol.IdRol = 0;

            //creacion de la lista de objetos para recibir la lista que va entregar el metodo get all

            usuario.Usuarios = new List<object>();
            //llamar al metodo del bl que ejecuta el store procedure 

            ML.Result result = BL.Usuario.GetAllEF(usuario);

            //si la ejecucion del store procedure es exitosa 
            // se asigna la lista obtenida a la lista que esta en usuarios 
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }

            ViewBag.Title = "Usuarios";

            return View(usuario);
        }
        //post 
        [HttpPost]
        //metodo post 
        public ActionResult GetAll(ML.Usuario usuario)
        {

            usuario.Nombre = (usuario.Nombre == null) ? "" : usuario.Nombre;
            usuario.ApellidoPaterno = (usuario.ApellidoPaterno == null) ? "" : usuario.ApellidoPaterno;
            usuario.ApellidoMaterno = (usuario.ApellidoMaterno == null) ? "" : usuario.ApellidoMaterno;
           // usuario.Rol  = new ML.Rol();
            usuario.Rol.IdRol = (usuario.Rol.IdRol == null) ? 0 : usuario.Rol.IdRol;
            ML.Result lista = new ML.Result();
            lista = BL.Rol.GetAllEF();
            usuario.Rol.Roles = lista.Objects; 

            
            usuario.Usuarios = new List<object>();
            ML.Result result = BL.Usuario.GetAllEF(usuario);
            if (result.Correct)
            {
                usuario.Usuarios = result.Objects;
            }
            else
            {
                ViewBag.Message = result.ErrorMessage;

            }

            ViewBag.Title = "Usuarios";

            return View(usuario);



            
        }






        [HttpGet]
        public ActionResult Form(byte? IdUsuario)

        {



            ML.Usuario usuario = new ML.Usuario();
            usuario.Rol = new ML.Rol();
            ML.Result resultRol = BL.Rol.GetAllEF();
            usuario.Rol.Roles = resultRol.Objects;
            usuario.Direccion = new ML.Direccion();
            usuario.Direccion.Colonia = new ML.Colonia();
            usuario.Direccion.Colonia.Municipio = new ML.Municipio();
            usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
            usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
            ML.Result resultPais = BL.Pais.GetAllPais();//cambiar por el metodo get all 
            usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;




            if (IdUsuario == null)

            {
                usuario.Rol.Roles = resultRol.Objects;
                ViewBag.Accion = "Agregar Usuario";
            }

            else

            {
                usuario.IdUsuario = (byte)IdUsuario;
                ML.Result result = BL.Usuario.GetByIDEF(usuario);

                if (result.Correct)
                {
                    usuario = (ML.Usuario)result.Object;
                }
                //aqui se tiene que actualizar todos los datos de paises 
                /*
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                
                usuario.Rol.Roles = resultRol.Objects;*/
                ML.Result resultPais2 = BL.Pais.GetAllPais();
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais2.Objects;
                ViewBag.Accion = "Actualizar datos";
                //BL.Usuario.UpdateLINQ(usuario);
                if (usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais != null)
                {

                    ML.Result resultEstado = BL.Estado.EstadoGetByIdPais(usuario.Direccion.Colonia.Municipio.Estado.Pais.IdPais.Value);
                    ML.Result resultMunicipio = BL.Municipio.GetByIdEstado(usuario.Direccion.Colonia.Municipio.Estado.IdEstado.Value);
                    ML.Result ResultColonia = BL.Colonia.GetByIdMunicipio(usuario.Direccion.Colonia.Municipio.IdMunicipio.Value);


                    usuario.Direccion.Colonia.Municipio.Estado.Estados = resultEstado.Objects;
                    usuario.Direccion.Colonia.Municipio.Municipios = resultMunicipio.Objects;
                    usuario.Direccion.Colonia.Colonias = ResultColonia.Objects;

                }




            }
            //cambiar por el metodo get all 
             usuario.Rol.Roles = resultRol.Objects;
            
            //aqui ya van los dat
            return View(usuario);
        }

        [HttpPost]

        //aqui van a ir validaciones 
        public ActionResult Form( ML.Usuario usuario,HttpPostedFileBase fuImagen)

        {
           
            
          ML.Result result = new ML.Result();

            if(ModelState.IsValid)
            {
                if (usuario.IdUsuario == 0)

                {
                    if (fuImagen != null)
                    {
                        usuario.Imagen = convertFileToByteArray(fuImagen);
                    }


                    //se tiene que cachar el resultado del result 
                    result = BL.Usuario.AddEF(usuario);
                    //return View(usuario);

                    if (result.Correct)
                    {
                        ViewBag.Mensaje = result.ErrorMessage;
                        //ViewBag.Mesaje = "prueba";
                        return View("Modal");
                    }
                    else
                    {
                        return View();
                    }



                }

                else

                {
                    if (fuImagen != null)
                    {
                        usuario.Imagen = convertFileToByteArray(fuImagen);
                    }

                    if (usuario.Direccion.IdDireccion == null)
                    {
                        usuario.Direccion.IdDireccion = 0;
                    }


                    result = BL.Usuario.UpdateEF(usuario);
                    if (result.Correct)
                    {
                        ViewBag.Mensaje = result.ErrorMessage;
                        return View("Modal");
                    }
                    else { return View(); }



                }
            }
            else
            {
                usuario.Direccion = new ML.Direccion();
                usuario.Direccion.Colonia = new ML.Colonia();
                usuario.Direccion.Colonia.Municipio = new ML.Municipio();
                usuario.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                usuario.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                ML.Result resultPais = BL.Pais.GetAllPais();//cambiar por el metodo get all 
                usuario.Direccion.Colonia.Municipio.Estado.Pais.Paises = resultPais.Objects;
                //usuario.Rol = new ML.Rol();
                ML.Result resultRol = BL.Rol.GetAllEF();
                usuario.Rol.Roles = resultRol.Objects;
                return View(usuario);
            }

            

        }

        //[HttpDelete]
        public ActionResult Delete(byte IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            usuario.IdUsuario = IdUsuario;
            ML.Result result = new ML.Result();
            result = BL.Usuario.DeleteEF(usuario);
            ViewBag.Mensaje = result.ErrorMessage;




            return View("Modal");
        }

        public ActionResult Buscar()
        {

            ViewBag.Mensaje = "Ingrese los terminos de busqueda";



            return View("Buscar");
        }

        public byte[] convertFileToByteArray (HttpPostedFileBase fuImagen)
        {
            MemoryStream target = new MemoryStream(); ;
            fuImagen.InputStream.CopyTo(target);
            byte[] data = target.ToArray();
            return data;
        }

        public JsonResult GetEstado(int IdPais)
        {
            var result = BL.Estado.EstadoGetByIdPais(IdPais);

            return Json(result.Objects);
        }

        public JsonResult GetMunicipio(int IdEstado)
        {
            var result = BL.Municipio.GetByIdEstado(IdEstado);

            return Json(result.Objects);
        }

        public JsonResult GetColonia(int IdMunicipio)
        {
            var result = BL.Colonia.GetByIdMunicipio(IdMunicipio);

            return Json(result.Objects);
        }



        [HttpPost]
        public JsonResult CambiarEstatus(byte idUsuario, bool estatus)
        {
            ML.Result result = BL.Usuario.ChangeStatus(idUsuario, estatus);

            return Json(result);
        }
       


        /*
          [HttpGet]//Abre la vista o el formulario
        public ActionResult Form(int? IdMateria) 
        { 
            if (IdMateria == null)
            {
                //add
                //Mostrar un formulario vacio
                ViewBag.Accion = "Agregar";
                return View();
            }
            else
            {
                //GetbyId
                //Mostrar un formulario con los datos del registro seleccionado
                ViewBag.Accion = "Actualizar";
                return View();
            }


        }

        [HttpPost]//recibe la información que viene desde el formulario
        public ActionResult Form(ML.Materia materia)
        {
            ML.Result result = new ML.Result();

            if (materia.IdMateria == 0)
            {
                //add
                result = BL.Materia.AddEF(materia);

                if (result.Correct)
                {
                     ViewBag.Mensaje = result.Message;
                    return View("Modal");
                }
                else
                {
                    return View();
                }


            }
            else
            {
                //Update

                result = BL.Materia.UpdateEF(materia);
                return View();
            }


        }
         */


    }
}