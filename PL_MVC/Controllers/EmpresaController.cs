using Aspose.Cells;
using ML;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL_MVC.Controllers
{
    public class EmpresaController : Controller
    {


        //public ActionResult GetAll()
        //{
        //    ML.Result resultSubCategoria = new ML.Result();
        //    resultSubCategoria.Objects = new List<Object>();

        //    using (var client = new HttpClient())
        //    {
        //        client.BaseAddress = new Uri("http://localhost:40840/api/");

        //        var responseTask = client.GetAsync("usuario/" + idUsuario);
        //        responseTask.Wait();

        //        var result = responseTask.Result;

        //        if (result.IsSuccessStatusCode)
        //        {
        //            var readTask = result.Content.ReadAsAsync<ML.Result>();
        //            readTask.Wait();

        //            foreach (var resultItem in readTask.Result.Objects)
        //            {
        //                ML.SubCategoria resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.SubCategoria>(resultItem.ToString());
        //                resultSubCategoria.Objects.Add(resultItemList);
        //            }
        //        }
        //    }
        //    return View(resultSubCategoria);
        //}




        // GET: Empresa
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            result.Objects = new List<object>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["url"]);
                var responseTask = client.GetAsync("empresa/getall");
                    responseTask.Wait();

                      var  resultado = responseTask.Result;

                if (resultado.IsSuccessStatusCode)
                {
                    var readTask = resultado.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();

                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Empresa resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empresa>(resultItem.ToString());
                        result.Objects.Add(resultItemList);
                    }
                }




            }




            //aqui empieza el antiguo codigo del gelall
            //ML.Empresa empresa = new ML.Empresa();
            //empresa.Empresas = new List<object>();
            //EmpresaServices.EmpresaClient servicio = new EmpresaServices.EmpresaClient();
            //ML.Result result = servicio.EmpresaGetAll();

            //// ML.Result result = BL.Empresa.EmpresaGetAll();
            //if (result.Correct)
            //{
            //    empresa.Empresas = result.Objects;
            //}
            //else
            //{
            //    ViewBag.Message = result.ErrorMessage;

            //}

            //ViewBag.Title = "Empresas";

            ML.Empresa empresa = new ML.Empresa();
            empresa.Empresas = result.Objects;

            return View(empresa);






        }


        //el form pero de la empresa 
        [HttpGet]
        public ActionResult Form(int? IdEmpresa)

        {



            ML.Empresa empresa = new ML.Empresa();
            //usuario.Rol = new ML.Rol();
            //ML.Result result = BL.Rol.GetAllEF();
            //usuario.Rol.Roles = resultRol.Objects;

            if (IdEmpresa == null)

            {
                ViewBag.Accion = "Agregar Empresa";
            }

            else

            {


                ML.Result result = new ML.Result();
                try
                {
                    string urlAPI = System.Configuration.ConfigurationManager.AppSettings["url"];
                    using (var client = new HttpClient())
                    {
                        client.BaseAddress = new Uri(urlAPI);//"api/empresa/getbyid/{IdEmpresa}"
                        var responseTask = client.GetAsync("empresa/getbyid/" + IdEmpresa);
                        responseTask.Wait();
                        var resultAPI = responseTask.Result;
                        if (resultAPI.IsSuccessStatusCode)
                        {
                            var readTask = resultAPI.Content.ReadAsAsync<ML.Result>();
                            readTask.Wait();
                            ML.Empresa resultItemList = new ML.Empresa();
                            resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Empresa>(readTask.Result.Object.ToString());
                            result.Object = resultItemList;

                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No existen registros en la tabla Departamento";
                        }

                    }
                }

                catch (Exception ex)
                {
                    result.Correct = false;
                    result.ErrorMessage = ex.Message;

                }
                empresa = (ML.Empresa)result.Object;
                //return View(empresa);
            }
            //empresa.IdEmpresa = IdEmpresa;

            //EmpresaServices.EmpresaClient servicio = new EmpresaServices.EmpresaClient();
            //ML.Result result = servicio.EmpresaGetById(empresa);

            ////ML.Result result = BL.Empresa.EmpresaGetById(empresa);

            //if (result.Correct)
            //{
            //    empresa = (ML.Empresa)result.Object;
            //}

            //// usuario.Rol.Roles = resultRol.Objects;

            ////BL.Usuario.UpdateLINQ(usuario);
            //ViewBag.Accion = "Actualizar datos";



        
            return View(empresa);
        }

        [HttpPost]


        public ActionResult Form(ML.Empresa empresa)

        {
            ML.Result result = new ML.Result();

            if (empresa.IdEmpresa == null)

            {


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["url"]);

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<ML.Empresa>("empresa/add", empresa);
                    postTask.Wait();

                    var resultado = postTask.Result;
                    if (resultado.IsSuccessStatusCode)
                    {

                        ViewBag.Mesaje = "Agregado correctamente";
                        return View("Modal");
                        //return RedirectToAction("GetAll");
                    }
                    else
                    {
                        ViewBag.Mesaje = "No fue agregado correctamente";
                        return View("Modal");
                    }
                }

                //return View("GetAll");
                /* if (fuImagen != null)
                 {
                     usuario.Imagen = convertFileToByteArray(fuImagen);
                 }*/


                // DepartamentoService.DepartamentoClient departamentoClient = new DepartamentoService.DepartamentoClient();
                // var result = departamentoClient.GetAll();

                // aqui empieaza en antiguo
                // EmpresaSoap.EmpresaClient emp = new EmpresaSoap.EmpresaClient();
                // result = emp.EmpresaAdd(empresa);
                // //se tiene que cachar el resultado del result 
                //// result = BL.Empresa.EmpresaAdd(empresa);
                // //return View(usuario);

                // if (result.Correct)
                // {
                //     ViewBag.Mensaje = result.ErrorMessage;
                //     //ViewBag.Mesaje = "prueba";
                //     return View("Modal");
                // }
                // else
                // {
                //     return View();
                // }



            }

            else

            {


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(ConfigurationManager.AppSettings["url"]);

                    //HTTP POST
                    //var postTask = client.PostAsJsonAsync<ML.SubCategoria>("subcategoria/update", subcategoria);
                    var putTask = client.PutAsJsonAsync<ML.Empresa>("empresa/update" , empresa);
                    putTask.Wait();

                    var resultado = putTask.Result;
                    if (resultado.IsSuccessStatusCode)
                    {
                        ViewBag.Mensaje = "empresa actualizada correctamente";
                        return View("Modal");
                    }
                }

                return View("Modal");

            }
            //aqui empieza el codigo antiguo 
            /*  if (fuImagen != null)
              {
                  usuario.Imagen = convertFileToByteArray(fuImagen);
              }*/
            // EmpresaSoap2.EmpresaClient emp = new EmpresaSoap2.EmpresaClient();
            // result = emp.EmpresaUpdate(empresa);
            //// result = BL.Empresa.EmpresaUpdate(empresa);
            // if (result.Correct)
            // {
            //     ViewBag.Mensaje = result.ErrorMessage;
            //     return View("Modal");
            // }
            // else { return View(); }



        

        }

        //[HttpDelete]
        public ActionResult Delete(int IdEmpresa)
        {
            //se
            ML.Result resultado = new ML.Result();
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ConfigurationManager.AppSettings["url"]);

                //HTTP POST
                var deleteTask = client.DeleteAsync("empresa/delete/" + IdEmpresa);
                deleteTask.Wait();
                ////se tiene que esperar por uqe es asincrono 
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    ViewBag.message = "borrado correctamente";
                    return View("Modal");
                }
            }


            //codigo antiguo 
            // ML.Empresa empresa = new ML.Empresa();
            // empresa.IdEmpresa = IdEmpresa;
            // ML.Result result = new ML.Result();

            // EmpresaServices.EmpresaClient servicio = new EmpresaServices.EmpresaClient();
            // result = servicio.EmpresaDelete(empresa);
            //// result = BL.Empresa.EmpresaDelete(empresa);
            // ViewBag.Mensaje = result.ErrorMessage;
            return View("Modal");



            // return View("Modal");
        }


        [HttpGet]
        public ActionResult CargaMasiva()
        {
            return View();
        }



        [HttpPost]
        public ActionResult CargaMasiva(HttpPostedFileBase archivo)//se recibe un archivo txt
        {

            using (StreamReader file = new StreamReader(archivo.InputStream))//se crea un using para leer el archivo
            {
                string row = file.ReadLine();//se lee la primera linea que tiene los encabezados 


                while (!file.EndOfStream)//hasta que termine el archivo vas a leer linea por linea 
                {
                    row = file.ReadLine(); //lee linea 
                    string[] rowFinal = row.Split('|');//separa la linea en un arreglo de string cada que encuentre un '|'

                    ML.Empresa empresa = new ML.Empresa(); //instanciar al objeto ML.Empresa
                    empresa.Nombre = rowFinal[0];//se ingresan los datos en orden en el objeto 
                    empresa.Telefono = rowFinal[1];
                    empresa.DireccionWeb = rowFinal[2];
                    empresa.Email = rowFinal[3];
                    ML.Result result = BL.Empresa.EmpresaAdd(empresa);//se inserta en la base de datos 
                }

            }
            return View("CargaMasiva");
        }


        //[HttpPost]
        //public ActionResult CargaMasiva(HttpPostedFileBase archivo)
        //{

        //    using (Workbook wb = new Workbook(archivo.InputStream))
        //    {

        //        WorksheetCollection collection = wb.Worksheets;
        //        for(int workSheetIndex = 0;workSheetIndex < collection.Count;workSheetIndex++)
        //        {

        //            Worksheet worksheet = collection[workSheetIndex];

        //            int rows = worksheet.Cells.MaxDataRow;
        //            int cols = worksheet.Cells.MaxDataColumn;

        //            for(int i=1; i<rows +1;i++)
        //            {

        //                ML.Empresa empresa = new ML.Empresa();
        //                empresa.Nombre = worksheet.Cells[i, 0].GetStringValue(CellValueFormatStrategy.CellStyle);
        //                empresa.Telefono = worksheet.Cells[i, 1].GetStringValue(CellValueFormatStrategy.CellStyle);
        //                empresa.DireccionWeb = worksheet.Cells[i, 2].GetStringValue(CellValueFormatStrategy.CellStyle);
        //                empresa.Email = worksheet.Cells[i, 3].GetStringValue(CellValueFormatStrategy.CellStyle);
        //                ML.Result result = BL.Empresa.EmpresaAdd(empresa);
        //            }


        //        }
        //    }
        //    return View("CargaMasiva");
        //}

        [HttpGet]

        public ActionResult CargaMasivaEmpresa()
        {
            ML.Empresa empresa = new ML.Empresa();
            empresa.Empresas = new List<object>();
            //ML.Result result = BL.Empresa.EmpresaGetAll();
            //if (result.Correct)
            //{
            //    empresa.Empresas = result.Objects;
            //}
            //else
            //{
            //    ViewBag.Message = result.ErrorMessage;

            //}

            ViewBag.Title = "Empresas";

            return View(empresa);
        }



        [HttpPost]
        public ActionResult CargaMasivaEmpresa(HttpPostedFileBase excel)
        {
            ML.Empresa empresa = new ML.Empresa();


            if (Session["filePath"] == null)
            {

                if (excel != null)//revisa que se haya ingresado un archivo
                {
                    string extensionArchivo = Path.GetExtension(excel.FileName).ToLower();//obtiene la extension del archivo y la convierte a minusculas
                    string extesionValida = ConfigurationManager.AppSettings["TipoExcel"];

                    if (extensionArchivo == extesionValida)
                    {
                        string rutaproyecto = Server.MapPath("~/EmpresaCarga/");
                        string filePath = rutaproyecto + Path.GetFileNameWithoutExtension(excel.FileName) + '-' + DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + extesionValida;

                        if (!System.IO.File.Exists(filePath))
                        {

                            excel.SaveAs(filePath); //crear copia

                            ViewBag.Mensaje = "archivo cargado correctamente";


                            string connectionStringExcel = ConfigurationManager.AppSettings["ConexionExcel"];
                            empresa = BL.Empresa.CargaMasivaExcel(empresa, filePath, connectionStringExcel);

                            if (empresa.isValidExcel == true)
                            {
                                Session["filePath"] = filePath;
                            }
                            else
                            {

                            }





                            ViewBag.Title = "Empresas";

                            return View(empresa);
                            //return View("Modal");

                        }

                    }
                    else
                    {
                        ViewBag.Mensaje = "Por favor seleccione un archivo tipo .xlsx";
                        return View("Modal");
                    }
                }
                else
                {
                    ViewBag.Mensaje = "Por favor seleccione un archivo";
                    return View("Modal");
                }

            }
            else
            {
                string filepath = Session["filePath"].ToString(); //recuperando la informacion de la session

                if (filepath != null)
                {

                    string connectionStringExcel = ConfigurationManager.AppSettings["ConexionExcel"];
                    empresa = BL.Empresa.CargaMasivaExcel(empresa, filepath, connectionStringExcel);

                    foreach (ML.Empresa item in empresa.Empresas)
                                    {
                                        //ML.Empresa row = new ML.Empresa();
                                        //row.Nombre = item.Nombre;
                                        //row.Telefono = item.Telefono;
                                        //row.DireccionWeb = item.DireccionWeb;   
                                        //row.Email = item.Email;
                                        
                                        ML.Result result = BL.Empresa.EmpresaAdd(item);
                        if (!result.Correct)
                        {
                            string error = "Ocurrio un error al insertar el usuario con correo: ";
                           result.ErrorMessage = error;

                        }


                    }


                        ViewBag.Mensaje = "carga masiva exitosa";

                    Session["pathExcel"] = null;
                    return View("Modal");
                }

               




                //srchivo.PostedFile.SaveAs(rutaAbsoluta);

                // string ruta = "C:\\Users\\digis\\Documents\\Luis Angel Ramírez Galicia\\LRamírezProgramacionNCapas\\PL_MVC\\EmpresaCarga\\";
                // string tiempo = DateTime.Now.ToString("dd-MM-yyyy_HH-mm");
                //string nombre = archivo.FileName.ToString();
                // archivo.SaveAs(ruta + tiempo + nombre);

                //using (OleDbConnection connection = new OleDbConnection(connectionString))
                //{
                //    // The insertSQL string contains a SQL statement that
                //    // inserts a new row in the source table.
                //    OleDbCommand command = new OleDbCommand(insertSQL);

                //    // Set the Connection to the new OleDbConnection.
                //    command.Connection = connection;

                //    // Open the connection and execute the insert command.
                //    try
                //    {
                //        connection.Open();
                //        command.ExecuteNonQuery();
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine(ex.Message);
                //    }
                //    // The connection is automatically closed when the
                //    // code exits the using block.
                //}

            }





            return View(empresa);



            /*  public byte[] convertFileToByteArray(HttpPostedFileBase fuImagen)
              {
                  MemoryStream target = new MemoryStream(); ;
                  fuImagen.InputStream.CopyTo(target);
                  byte[] data = target.ToArray();
                  return data;
              }*/


        }
    }
}