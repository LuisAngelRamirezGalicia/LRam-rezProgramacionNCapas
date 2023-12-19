using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
 public class Dependiente
    {
        public static ML.Result DependienteAdd(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.DependienteAdd(dependiente.Empleado.NumeroEmpleado, dependiente.Nombre, dependiente.ApellidoPaterno, dependiente.ApellidoMaterno, dependiente.FechaNacimiento, dependiente.EstadoCivil, dependiente.Genero, dependiente.Telefono, dependiente.RFC, dependiente.DependienteTipo.IdDependienteTipo);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "el dependiente se inserto correctamente";
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "no se inserto el dependiente correctamente ";
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

        public static ML.Result DependienteUpdate(ML.Dependiente dependiente)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.DependienteUpdate(dependiente.IdDependiente,dependiente.Nombre, dependiente.ApellidoPaterno, dependiente.ApellidoMaterno, dependiente.FechaNacimiento, dependiente.EstadoCivil, dependiente.Genero, dependiente.Telefono, dependiente.RFC, dependiente.DependienteTipo.IdDependienteTipo);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedu

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

        public static ML.Result DependienteGetByNumeroEmpleado(string numeroEmpleado)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = context.DependienteGetByNumeroEmpleado(numeroEmpleado);

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            //ML.Materia materia = new ML.Materia();
                            ML.Dependiente  dependiente = new ML.Dependiente();

                            /*  materia.IdMateria = row.IdMateria;
                              materia.Nombre = row.Nombre;
                              materia.Creditos = row.Creditos.Value;
                              materia.Costo = row.Costo.Value;

                              materia.Semestre = new ML.Semestre();
                              materia.Semestre.IdSemestre = row.IdSemestre.Value;
                              result.Objects.Add(materia);*/
                            dependiente.IdDependiente = row.IdDependiente;
                            dependiente.Empleado = new ML.Empleado();  
                            dependiente.Empleado.NumeroEmpleado = row.NumeroEmpleado;
                            dependiente.Nombre = row.DependienteNombre;
                            dependiente.ApellidoPaterno = row.ApellidoPaterno;
                            dependiente.ApellidoMaterno = row.ApellidoMaterno;
                            dependiente.FechaNacimiento = row.FechaNacimiento.Value;
                            dependiente.EstadoCivil = row.EstadoCivil;  
                            dependiente.Genero = row.Genero;
                            dependiente.Telefono = row.Telefono;
                            dependiente.RFC = row.RFC;
                            dependiente.DependienteTipo = new ML.DependienteTipo();
                            dependiente.DependienteTipo.IdDependienteTipo = row.IdDependienteTipo.Value;
                            dependiente.DependienteTipo.Nombre = row.tipo;
                            
                                


                            result.Objects.Add(dependiente);

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

        public static ML.Result DependienteGetById(int  idDependiente)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var row = context.DependienteGetByIdDependiente(idDependiente).FirstOrDefault();
                    //este store procedure no va en una lista porque da un solo resultado 

                    if (row != null)
                    {
                        //
                        // ML.Usuario
                        ML.Dependiente dependiente = new ML.Dependiente();

                        /*  materia.IdMateria = row.IdMateria;
                          materia.Nombre = row.Nombre;
                          materia.Creditos = row.Creditos.Value;
                          materia.Costo = row.Costo.Value;

                          materia.Semestre = new ML.Semestre();
                          materia.Semestre.IdSemestre = row.IdSemestre.Value;
                          result.Objects.Add(materia);*/
                        dependiente.IdDependiente = row.IdDependiente;
                        dependiente.Empleado = new ML.Empleado();
                        dependiente.Empleado.NumeroEmpleado = row.NumeroEmpleado;
                        dependiente.Nombre = row.DependienteNombre;
                        dependiente.ApellidoPaterno = row.ApellidoPaterno;
                        dependiente.ApellidoMaterno = row.ApellidoMaterno;
                        dependiente.FechaNacimiento = row.FechaNacimiento.Value;
                        dependiente.EstadoCivil = row.EstadoCivil;
                        dependiente.Genero = row.Genero;
                        dependiente.Telefono = row.Telefono;
                        dependiente.RFC = row.RFC;
                        dependiente.DependienteTipo = new ML.DependienteTipo();
                        dependiente.DependienteTipo.IdDependienteTipo = row.IdDependienteTipo.Value;
                        dependiente.DependienteTipo.Nombre = row.tipo;




                        result.Object = dependiente;
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

        public static ML.Result DependienteDelete(int idDependiente)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.DependienteDelete(idDependiente);  // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "se borro el Dependiente correctamente";
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
