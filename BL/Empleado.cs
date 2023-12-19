using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result EmpleadoAdd(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.EmpleadoAdd(empleado.NumeroEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email, empleado.Telefono,empleado.FechaNacimiento, empleado.NSS, empleado.Foto, empleado.Empresa.IdEmpresa);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "el empleado se inserto correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "no se inserto el empleado correctamente ";
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

        public static ML.Result EmpleadoUpdate(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.EmpleadoUpdate(empleado.NumeroEmpleado, empleado.RFC, empleado.Nombre, empleado.ApellidoPaterno, empleado.ApellidoMaterno, empleado.Email, empleado.Telefono, empleado.FechaNacimiento, empleado.NSS, empleado.FechaIngreso, empleado.Foto, empleado.Empresa.IdEmpresa);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "el empleado se actualizo correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "no se actualizo el empleado correctamente ";
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


        public static ML.Result EmpleadoGetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = context.EmpleadoGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            //ML.Materia materia = new ML.Materia();
                            ML.Empleado empleado = new ML.Empleado();

                            /*  materia.IdMateria = row.IdMateria;
                              materia.Nombre = row.Nombre;
                              materia.Creditos = row.Creditos.Value;
                              materia.Costo = row.Costo.Value;

                              materia.Semestre = new ML.Semestre();
                              materia.Semestre.IdSemestre = row.IdSemestre.Value;
                              result.Objects.Add(materia);*/

                            empleado.NumeroEmpleado = row.NumeroEmpleado;
                            empleado.RFC = row.RFC;
                            empleado.Nombre = row.EmpleadoNombre;
                            empleado.ApellidoPaterno = row.ApellidoPaterno;
                            empleado.ApellidoMaterno = row.ApellidoMaterno;
                            empleado.Email = row.Email;
                            empleado.Telefono = row.Telefono;
                            empleado.FechaNacimiento = row.FechaNacimiento.Value;
                            empleado.NSS = row.NSS;
                            empleado.FechaIngreso = row.FechaIngreso.Value;
                            empleado.Foto = row.Foto;
                            empleado.Empresa = new ML.Empresa();
                            empleado.Empresa.Nombre = row.NombreEmpresa;
                        

                            result.Objects.Add(empleado);

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


        public static ML.Result EmpleadoGetById(ML.Empleado empleadoEntrada)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var row = context.EmpleadoGetById(empleadoEntrada.NumeroEmpleado).FirstOrDefault();
                    //este store procedure no va en una lista porque da un solo resultado 

                    if (row != null)
                    {
                        //
                        // ML.Usuario
                        ML.Empleado empleado= new ML.Empleado();

                        empleado.NumeroEmpleado = row.NumeroEmpleado;
                        empleado.RFC = row.RFC;
                        empleado.Nombre = row.Nombre;
                        empleado.ApellidoPaterno = row.ApellidoPaterno;
                        empleado.ApellidoMaterno = row.ApellidoMaterno;
                        empleado.Email = row.Email;
                        empleado.Telefono = row.Telefono;
                        empleado.FechaNacimiento = row.FechaNacimiento.Value;
                        empleado.NSS = row.NSS;
                        empleado.FechaIngreso = row.FechaIngreso.Value;
                        empleado.Foto = row.Foto;
                        empleado.Empresa = new ML.Empresa();
                        empleado.Empresa.IdEmpresa = row.idEmpresa.Value;



                        result.Object = empleado;

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


        public static ML.Result EmpleadoDelete(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.EmpleadoDelete(empleado.NumeroEmpleado);  // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "se borro el empleado correctamente";
                        result.Correct = true;
                    }
                    /* else
                     {
                         result.Correct = false;
                         result.ErrorMessage = "No se insertó el registro";
                     }*/

                    // result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "No se insertó el registro" + result.Ex;
            }
            return result;
        }





    }
}
