using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; //Dataset, datatables
using System.Data.OleDb; //OleDbConnection
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace BL
{
    public class Empresa
    {
        public static ML.Result EmpresaAdd(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.EmpresaAdd(empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "la empresa se agrego correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó la empresa ";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }



        /// empresa updte
        /// 

        public static ML.Result EmpresaUpdate(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.EmpresaUpdate(empresa.IdEmpresa, empresa.Nombre, empresa.Telefono, empresa.Email, empresa.DireccionWeb);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "la empresa se actualizo correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo la empresa ";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        public  static ML.Empresa CargaMasivaExcel(ML.Empresa empresa,string rutaArchivo,string cadenaConexion)
        {
            ML.Result result = new ML.Result();
            
            try
            {
                using (OleDbConnection context = new OleDbConnection (cadenaConexion + rutaArchivo)) 
                {
                    string query = "SELECT * FROM[Hoja1$]";
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandText = query;
                        cmd.Connection = context;
                        OleDbDataAdapter da = new OleDbDataAdapter();
                        da.SelectCommand = cmd;
                        DataTable tablaEmpresa = new DataTable();
                        try
                        {
                        da.Fill(tablaEmpresa);
                        }

                        catch (Exception ex)
                        {
                            result.Correct = false;
                            result.ErrorMessage = "No se actualizo la empresa ";
                        }

                        if(tablaEmpresa.Rows.Count > 0)
                        {result.Correct = true;
                            empresa.isValidExcel = true;
                            result.Objects = new List<object>();

                            foreach  (DataRow row in tablaEmpresa.Rows)
                            {
                                ML.Empresa item = new ML.Empresa();

                                
                                item.Nombre = row[0].ToString();
                                item.Telefono = row[1].ToString();
                                item.DireccionWeb = row[2].ToString();
                                item.Email = row[3].ToString();

                                string errores = ValidarDatos(item);

                                if(errores == "")
                                {
                                    item.isValidExcel = true;
                                    item.ErrorMessage = "";
                                }
                                else
                                {
                                    item.ErrorMessage = errores;
                                    item.isValidExcel = false;
                                    empresa.isValidExcel = false;
                                }

                                result.Objects.Add(item);

                            }

                            empresa.Empresas = new List<object>();
                            //
                            if (result.Correct)
                            {
                                empresa.Empresas = result.Objects;
                            }
                            else
                            {
                                empresa.isValidExcel = false;

                            }


                        }

                    }
                
                }
            }

            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = "No se actualizo la empresa ";
            }

            return empresa;
        }

        public static string ValidarDatos(ML.Empresa empresa)
        {
            string errores = "";
            //string noSimbolos = @"^[a-zA-Z0-9]+$";
            if (empresa.Nombre == "")
            {

                errores = "El nombre no peude ser nulo ";
            }
            else
            { 
                if (Regex.IsMatch(empresa.Nombre, @"^[a-zA-Z0-9 ]+$"))
                {
                    
                }
                else
                {
                    errores = errores + "el nombre de la empresa no debe de llevar simbolos especiales";
                }

            }
            


            if (empresa.Telefono == "")
            {
                errores = errores +  "El Telefono no peude ser nulo ";
            }
            else
            {
                if (Regex.IsMatch(empresa.Telefono, @"^\d{10}$"))
                {

                }
                else
                {
                    errores = errores + "solo se permiten numeros de 10 digitos";
                }

            }


            if (empresa.DireccionWeb == "")
            {
                errores = errores + "La direccion  no puede ser nula";
            }
            else
            {
                if (Regex.IsMatch(empresa.DireccionWeb, @"^https?:\/\/[\w\-]+(\.[\w\-]+)+[/#?]?.*$"))
                {

                }
                else
                {
                    errores = errores + "direccion web no valida";
                }

            }


            if (empresa.Email == "")
            {
                errores = errores + "El Email no peude ser nulo ";
            }
            else
            {//^([a-zA-z0-9_\.\-\+])+\@@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$
                
                if (IsEmailValid(empresa.Email))
                {

                }
                else
                {
                    errores = errores + "email no valido";
                }

            }


            return errores;
        }

        public static bool IsEmailValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        public static ML.Result EmpresaDelete(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.EmpresaDelete(empresa.IdEmpresa);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "la empresa se borro correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo la empresa ";
                    }

                    result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        public static ML.Result EmpresaGetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = context.EmpresaGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            //ML.Materia materia = new ML.Materia();
                            ML.Empresa empresa = new ML.Empresa();

                            /*  materia.IdMateria = row.IdMateria;
                              materia.Nombre = row.Nombre;
                              materia.Creditos = row.Creditos.Value;
                              materia.Costo = row.Costo.Value;

                              materia.Semestre = new ML.Semestre();
                              materia.Semestre.IdSemestre = row.IdSemestre.Value;
                              result.Objects.Add(materia);*/

                            empresa.IdEmpresa = row.IdEmpresa;
                            empresa.Nombre = row.Nombre;
                            empresa.Telefono = row.Telefono;
                            empresa.Email = row.Email;
                            empresa.DireccionWeb = row.DireccionWeb;


                            result.Objects.Add(empresa);

                            //materia.Semestre = new ML.Semestre();
                            //materia.Semestre.IdSemestre = row.IdSemestre.Value;

                        }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
                //throw;
            }

            return result;
        }

        public static ML.Result EmpresaGetById(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = context.EmpresaGetByID(empresa.IdEmpresa).FirstOrDefault();
                    //este store procedure no va en una lista porque da un solo resultado 

                    if (query != null)
                    {
                        //
                        // ML.Usuario
                        ML.Empresa empresaResultado = new ML.Empresa();

                        empresaResultado.IdEmpresa = query.IdEmpresa;
                        empresaResultado.Nombre = query.Nombre;
                        empresaResultado.Telefono = query.Telefono;
                        empresaResultado.Email = query.Email;
                        empresaResultado.DireccionWeb = query.DireccionWeb;


                        result.Object = empresaResultado;

                        //materia.Semestre = new ML.Semestre();
                        //materia.Semestre.IdSemestre = row.IdSemestre.Value;

                        //   }

                        result.Correct = true;
                    }
                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
                //throw;
            }

            return result;
        }










        //LINQ
        /*
        public static ML.Result EmpresaAddLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    DL_EF.Empresa empresaLINQ = new DL_EF.Empresa();

                    // empresaLINQ.IdEmpresa = (int)empresa.IdEmpresa;
                    empresaLINQ.Nombre = empresa.Nombre;
                    empresaLINQ.Telefono = empresa.Telefono;
                    empresaLINQ.Email = empresa.Email;
                    empresa.DireccionWeb = empresa.DireccionWeb;

                    context.Empresas.Add(empresaLINQ);
                    int RowsAffected = context.SaveChanges();
                    //algo pasa con el add linq 
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Materia insertada correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        */

        public static ML.Result EmpresaAddLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    /*
                     DL_EF.Materia materiaLINQ = new DL_EF.Materia();

                     */
                    DL_EF.Empresa empresaLINQ = new DL_EF.Empresa();

                    // empresaLINQ.IdEmpresa = (int)empresa.IdEmpresa;
                    empresaLINQ.Nombre = empresa.Nombre;
                    empresaLINQ.Telefono = empresa.Telefono;
                    empresaLINQ.Email = empresa.Email;
                    empresaLINQ.DireccionWeb = empresa.DireccionWeb;

                    context.Empresas.Add(empresaLINQ);
                    int RowsAffected = context.SaveChanges();

                    //int query = context.UsuarioAdd(usuario.UserName, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Rol.IdRol, usuario.Nombre);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                        result.ErrorMessage = "Materia insertada correctamente";
                    }

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        // empresa update linq
        public static ML.Result EmpresaUpdateLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   /*
                     var materiaLINQ = (from queryLINQ in context.Materias //FROM Materia
                                       where queryLINQ.IdMateria == materia.IdMateria //WHERE IdMateria = 5
                                       select queryLINQ).SingleOrDefault();//SELECT IdMateria,Nombre,Costo,Creditos,IdSemestre

 
                     */

                    var empresaLINQ = (from queryLINQ in context.Empresas
                                       where queryLINQ.IdEmpresa == empresa.IdEmpresa
                                       select queryLINQ).SingleOrDefault();

                    if (empresaLINQ != null)
                    {
                        //DL_EF.Usuario  = new DL_EF.Usuario();
                        //usuarioLINQ.IdUsuario = usuario.IdUsuario;
                        empresaLINQ.Nombre = empresa.Nombre;
                        empresaLINQ.Telefono = empresa.Telefono;
                        empresaLINQ.DireccionWeb = empresa.DireccionWeb;
                        empresaLINQ.Email = empresa.Email;


                        //context.Usuario.Update(usuarioLINQ);
                        int RowsAffected = context.SaveChanges();

                        //int query = context.UsuarioAdd(usuario.UserName, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Rol.IdRol, usuario.Nombre);

                        //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                        // manda el procedure  y la conexion 
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Materia insertada correctamente";
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        /// detete empresa linq 
        /// 
        /// 
        public static ML.Result EmpresaDeleteLINQ(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {

                    var empresaLINQ = (from queryLINQ in context.Empresas
                                       where queryLINQ.IdEmpresa == empresa.IdEmpresa
                                       select queryLINQ).SingleOrDefault();

                    if (empresaLINQ != null)
                    {

                        context.Empresas.Remove(empresaLINQ);
                        //context.Usuario.Update(usuarioLINQ);
                        int RowsAffected = context.SaveChanges();

                        //int query = context.UsuarioAdd(usuario.UserName, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.CURP, usuario.Rol.IdRol, usuario.Nombre);

                        //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                        // manda el procedure  y la conexion 
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                            result.ErrorMessage = "Empresa borrada Linq correctamente";
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        /// empresa get all }
        /// 

        public static ML.Result EmpresaGetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = (from empresaLINQ in context.Empresas //FROM Materia
                                                                      //join rolLINQ in context.Rol on usuarioLINQ.IdRol equals rolLINQ.IdRol
                                                                      //  join aliasVaraiable in tablaModeloB on tablaModeloA.FK equals tablaModeloB.PK
                                 select new
                                 {
                                     IdEmpresa = empresaLINQ.IdEmpresa,
                                     Nombre = empresaLINQ.Nombre,
                                     Telefono = empresaLINQ.Telefono,
                                     Email = empresaLINQ.Email,
                                     DireccionWeb = empresaLINQ.DireccionWeb


                                 });

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = obj.IdEmpresa;
                            empresa.Nombre = obj.Nombre;
                            empresa.Telefono = obj.Telefono;
                            empresa.Email = obj.Email;
                            empresa.DireccionWeb = obj.DireccionWeb;





                            result.Objects.Add(empresa);
                        }





                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }



        public static ML.Result EmpresaGetByIdLINQ(ML.Empresa empresaEntrada)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = (from empresaLINQ in context.Empresas //FROM Materia
                                // join rolLINQ in context.Rol on usuarioLINQ.IdRol equals rolLINQ.IdRol
                                 where empresaLINQ.IdEmpresa == empresaEntrada.IdEmpresa
                                 //  join aliasVaraiable in tablaModeloB on tablaModeloA.FK equals tablaModeloB.PK
                                 select new
                                 {
                                     IdEmpresa = empresaLINQ.IdEmpresa,
                                     Nombre = empresaLINQ.Nombre,
                                     Telefono = empresaLINQ.Telefono,
                                     Email = empresaLINQ.Email,
                                     DireccionWeb = empresaLINQ.DireccionWeb
                                 }).SingleOrDefault();

                    /// EL Single Or Defaut sirve para aclarar que se retornna un solo objeto 
                    //  result.Objects = new List<object>();

                    if (query != null)
                    {
                        // foreach (var obj in query)
                        // {


                        ML.Empresa empresa = new ML.Empresa();

                            empresa.IdEmpresa = query.IdEmpresa;
                            empresa.Nombre = query.Nombre;
                            empresa.Telefono = query.Telefono;
                            empresa.Email = query.Email;
                            empresa.DireccionWeb = query.DireccionWeb;
                        result.Object = empresa;
                        //   }





                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }


    }

}
