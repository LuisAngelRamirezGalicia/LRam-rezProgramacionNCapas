using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ML;
using DL_EF;
using System.Security.Cryptography;
using System.Runtime.Remoting.Contexts;

namespace BL
{
    public class Usuario
    {

        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection()) //instanciar un objeto que será eliminado al termino del bloque using
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();

                    string query = "INSERT INTO [Usuario]([Nombres],[ApellidoPaterno],[ApellidoMaterno],[Edad])VALUES (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad)";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        //@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad

                        cmd.Parameters.AddWithValue("@Nombres", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                       // cmd.Parameters.AddWithValue("@Edad", usuario.Edad);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no pudo ser insertada correctamente";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }
            //
            //string query = "INSERT INTO [Usuario]([Nombres],[ApellidoPaterno],[ApellidoMaterno],[Edad])VALUES (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad)";

            //using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
            //{
            //     SqlCommand cmd = new SqlCommand("INSERT INTO [Usuario]([Nombres],[ApellidoPaterno],[ApellidoMaterno],[Edad])VALUES (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad)", conn);
            //      cmd.Parameters.AddWithValue("@Nombres", usuario.Nombres);
            //      cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
            //      cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
            //      cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
            //      conn.Open();
            //      cmd.ExecuteNonQuery();
            //  }

            return result;
        }
        public static ML.Result Update(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection()) //instanciar un objeto que será eliminado al termino del bloque using
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();

                    /*  //UPDATE Usuario
                      SET[Nombres] = 'sdfsd'
        ,[ApellidoPaterno] = 'dsbf'
        ,[ApellidoMaterno] = 'dsgdgs'
        ,[Edad] = 25
   WHERE id = 3
  GO*/

                    string query = "UPDATE [Usuario] SET [Nombres] = @Nombres,[ApellidoPaterno] =@ApellidoPaterno,[ApellidoMaterno]=@ApellidoMaterno,[Edad]=@Edad WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        //@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad
                        cmd.Parameters.AddWithValue("@ID", usuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@Nombres", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                      //  cmd.Parameters.AddWithValue("@Edad", usuario.Edad);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no pudo ser insertada correctamente";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }



            //
            //string query = "INSERT INTO [Usuario]([Nombres],[ApellidoPaterno],[ApellidoMaterno],[Edad])VALUES (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad)";

            //using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
            //{
            //     SqlCommand cmd = new SqlCommand("INSERT INTO [Usuario]([Nombres],[ApellidoPaterno],[ApellidoMaterno],[Edad])VALUES (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad)", conn);
            //      cmd.Parameters.AddWithValue("@Nombres", usuario.Nombres);
            //      cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
            //      cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
            //      cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
            //      conn.Open();
            //      cmd.ExecuteNonQuery();
            //  }

            return result;
        }

        public static ML.Result Delete(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (SqlConnection context = new SqlConnection()) //instanciar un objeto que será eliminado al termino del bloque using
                {
                    context.ConnectionString = DL.Conexion.GetConnectionString();
                    context.Open();

                    /*  //UPDATE Usuario
                      SET[Nombres] = 'sdfsd'
        ,[ApellidoPaterno] = 'dsbf'
        ,[ApellidoMaterno] = 'dsgdgs'
        ,[Edad] = 25
   WHERE id = 3
  GO*/

                    string query = "DELETE FROM  [Usuario]  WHERE ID = @ID";

                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        //@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad
                        cmd.Parameters.AddWithValue("@ID", usuario.IdUsuario);

                        int RowsAffected = cmd.ExecuteNonQuery();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "El usuario no pudo borrado correctamente";
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = ex.Message;
            }



            //
            //string query = "INSERT INTO [Usuario]([Nombres],[ApellidoPaterno],[ApellidoMaterno],[Edad])VALUES (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad)";

            //using (SqlConnection conn = new SqlConnection(DL.Conexion.GetConnectionString()))
            //{
            //     SqlCommand cmd = new SqlCommand("INSERT INTO [Usuario]([Nombres],[ApellidoPaterno],[ApellidoMaterno],[Edad])VALUES (@Nombres,@ApellidoPaterno,@ApellidoMaterno,@Edad)", conn);
            //      cmd.Parameters.AddWithValue("@Nombres", usuario.Nombres);
            //      cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
            //      cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
            //      cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
            //      conn.Open();
            //      cmd.ExecuteNonQuery();
            //  }

            return result;
        }

        // get all en bl 

        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {   //cadena que es el procedure
                    string query = "GetAll";
                    // manda el procedure  y la conexion 
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {   //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable usuarioTable = new DataTable();// creamos una tabla vacia

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                        sqlDataAdapter.Fill(usuarioTable); //llenar la tabla que estaba vacia

                        if (usuarioTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow item in usuarioTable.Rows)
                            {
                                ML.Usuario usuario = new ML.Usuario();

                                usuario.IdUsuario = byte.Parse(item[0].ToString());
                                usuario.Nombre = item[1].ToString();
                                usuario.ApellidoPaterno = item[2].ToString();
                                usuario.ApellidoMaterno = item[3].ToString();
                               // usuario.Edad = byte.Parse(item[4].ToString());


                                result.Objects.Add(usuario);


                            }

                            result.Correct = true;
                        }

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

        

        public static ML.Result GetByID(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {   //cadena que es el procedure

                    string query = "GetByID";

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@ID", usuario.IdUsuario);
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable usuarioTable = new DataTable();// creamos una tabla vacia

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                        sqlDataAdapter.Fill(usuarioTable); //llenar la tabla que estaba vacia

                        if (usuarioTable.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();

                            // foreach (DataRow item in usuarioTable.Rows)
                            //{
                            DataRow item = usuarioTable.Rows[0];
                            ML.Usuario usuarioResultado = new ML.Usuario();

                            usuarioResultado.IdUsuario = byte.Parse(item[0].ToString());
                            usuarioResultado.Nombre = item[1].ToString();
                            usuarioResultado.ApellidoPaterno = item[2].ToString();
                            usuarioResultado.ApellidoMaterno = item[3].ToString();
                           // usuarioResultado.Edad = byte.Parse(item[4].ToString());


                            result.Object = usuarioResultado;


                            //  }

                            result.Correct = true;
                        }

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


        /*
         public static ML.Result Add(ML.PlantelCarreraMateria plantelCarreraMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CAEEntities context = new DL.CAEEntities())
                {
                    var query = context.PlantelCarreraMateriaAdd(plantelCarreraMateria.PlantelCarrera.Id, plantelCarreraMateria.Materia.IdMateria, plantelCarreraMateria.Usuario.IdUser);
			

		    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
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

         */

        public static ML.Result AddProc(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion
                //
                string query = "UsuarioAdd"; 
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {   //cadena que es el procedure

                    

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 

                    context.Open();
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    { //@UserName,@ApellidoPaterno,@ApellidoMaterno,@Email,@Password,@Sexo,@Telefono,@Celular,@FechaNacimiento,@CURP,@IdRol,@Nombre
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nombre", usuario.Nombre);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", usuario.ApellidoPaterno);
                        cmd.Parameters.AddWithValue("@ApellidoMaterno", usuario.ApellidoMaterno);
                        cmd.Parameters.AddWithValue("@UserName", usuario.UserName);
                        cmd.Parameters.AddWithValue("@Email", usuario.Email);
                        cmd.Parameters.AddWithValue("@Password", usuario.Password);
                        cmd.Parameters.AddWithValue("@Sexo", usuario.Sexo);
                        cmd.Parameters.AddWithValue("@Celular", usuario.@Celular);
                        cmd.Parameters.AddWithValue("@FechaNacimiento", usuario.FechaNacimiento);
                        cmd.Parameters.AddWithValue("@IdRol", usuario.Rol.IdRol);
                        




                        //  cmd.Parameters.AddWithValue("@Edad", usuario.Edad);
                        

                       // DataTable usuarioTable = new DataTable();// creamos una tabla vacia

                      //  SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                       // sqlDataAdapter.Fill(usuarioTable); //llenar la tabla que estaba vacia

                        int RowsAffected = cmd.ExecuteNonQuery();

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
                result.Ex = ex;
                result.ErrorMessage = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
                //throw;
            }

            return result;
        }
        /*
         * public static ML.Result Add(ML.PlantelCarreraMateria plantelCarreraMateria)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.CAEEntities context = new DL.CAEEntities())
                {
                    var query = context.PlantelCarreraMateriaAdd(plantelCarreraMateria.PlantelCarrera.Id, plantelCarreraMateria.Materia.IdMateria, plantelCarreraMateria.Usuario.IdUser);
			

		    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
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

         */



        public static ML.Result AddEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.UsuarioAdd(usuario.UserName, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.Rol.IdRol, usuario.Nombre,usuario.Imagen,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                   if (query >= 1)
                    {   
                        result.Correct = true;
                        result.ErrorMessage = "se inserto correctamente";
                    }
                   /* else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
                    }*/

                    //result.Correct = true;

                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.Ex = ex;
                result.ErrorMessage = "No se insertó el registro" + result.Ex;
                //ex.Message;
            }
            return result;
        }


        public static ML.Result UpdateEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure
                    //actualizacion del los parametros del procedure 

                    int query = context.UsuarioUpdate(usuario.IdUsuario, usuario.UserName, usuario.ApellidoPaterno, usuario.ApellidoMaterno, usuario.Email, usuario.Password, usuario.Sexo, usuario.Telefono, usuario.Celular, usuario.FechaNacimiento, usuario.Rol.IdRol, usuario.Nombre, usuario.Imagen,usuario.Direccion.IdDireccion,usuario.Direccion.Calle,usuario.Direccion.NumeroInterior,usuario.Direccion.NumeroExterior,usuario.Direccion.Colonia.IdColonia);    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "se actualizo el usuario correctamente";
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

                result.ErrorMessage = ex.Message;
            }
            return result;
        }


        //delete ef
        public static ML.Result DeleteEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    int query = context.UsuarioDelete(usuario.IdUsuario);  // manda el procedure  y la conexion 
                    if (query >= 1)
                    {
                        result.ErrorMessage = "se borro el usuario correctamente";
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

        //get all entity framework 
        //public static ML.Result GetAllEF()
        //{
        //    ML.Result result = new ML.Result();

        //    try
        //    {
        //        using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
        //        {
        //            var query = context.UsuarioGetALL().ToList();

        //            if (query != null)
        //            {
        //                result.Objects = new List<object>();

        //                foreach (var queryRow in query)
        //                {
        //                    //ML.Materia materia = new ML.Materia();
        //                    ML.Usuario usuarioResultado = new ML.Usuario();

        //                    usuarioResultado.IdUsuario = queryRow.IdUsuario;
        //                    usuarioResultado.UserName = queryRow.UserName;
        //                    usuarioResultado.ApellidoPaterno = queryRow.ApellidoPaterno;
        //                    usuarioResultado.ApellidoMaterno = queryRow.ApellidoMaterno;
        //                    usuarioResultado.Email = queryRow.Email;
        //                    usuarioResultado.Password = queryRow.Password;
        //                    usuarioResultado.Sexo = queryRow.Sexo;
        //                    usuarioResultado.Telefono = queryRow.Telefono;
        //                    usuarioResultado.Celular = queryRow.Celular;
        //                    usuarioResultado.FechaNacimiento = queryRow.FechaNacimiento.Value.ToString("dd/MM/yyyy");
        //                    usuarioResultado.CURP = queryRow.CURP;
        //                    usuarioResultado.Rol = new ML.Rol();
        //                    usuarioResultado.Rol.IdRol = queryRow.IdRol;
        //                    usuarioResultado.Rol.NombreRol = queryRow.NombreRol;
        //                    usuarioResultado.Nombre = queryRow.UsuarioNombre;
        //                    usuarioResultado.Imagen = queryRow.Imagen;
        //                    usuarioResultado.Direccion = new ML.Direccion();
        //                    usuarioResultado.Direccion.IdDireccion = queryRow.IdDireccion;
        //                    usuarioResultado.Direccion.Calle = queryRow.Calle;
        //                    usuarioResultado.Direccion.NumeroExterior = queryRow.NumeroExterior;
        //                    usuarioResultado.Direccion.NumeroInterior = queryRow.NumeroInterior;
        //                    usuarioResultado.Direccion.Colonia = new ML.Colonia();
        //                    usuarioResultado.Direccion.Colonia.IdColonia = queryRow.IdColonia;
        //                    usuarioResultado.Direccion.Colonia.Nombre = queryRow.ColoniaNombre;

        //                    usuarioResultado.Direccion.Colonia.Municipio = new ML.Municipio();
        //                    usuarioResultado.Direccion.Colonia.Municipio.IdMunicipio = queryRow.IdMunicipio;
        //                    usuarioResultado.Direccion.Colonia.Municipio.Nombre = queryRow.MunicipioNombre;

        //                    usuarioResultado.Direccion.Colonia.Municipio.Estado = new ML.Estado();
        //                    usuarioResultado.Direccion.Colonia.Municipio.Estado.IdEstado = queryRow.IdEstado;
        //                    usuarioResultado.Direccion.Colonia.Municipio.Estado.Nombre = queryRow.EstadoNombre;

        //                    usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
        //                    usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais.IdPais = queryRow.IdPais;
        //                    usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais.Nombre = queryRow.PaisNombre;



        //                    result.Objects.Add(usuarioResultado);

        //                    //materia.Semestre = new ML.Semestre();
        //                    //materia.Semestre.IdSemestre = row.IdSemestre.Value;

        //                }

        //                result.Correct = true;
        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.Ex = ex;
        //        result.ErrorMessage = "Ocurrio un error al realizar la consulta en la base de datos " + result.Ex;
        //        //throw;
        //    }

        //    return result;
        //}

        public static ML.Result GetAllEF(ML.Usuario usuario)
        {//el error esta en el procedure 
            //
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = context.UsuarioGetALL(usuario.Nombre,usuario.ApellidoPaterno,usuario.ApellidoMaterno,usuario.Rol.IdRol).ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var queryRow in query)
                        {
                            //ML.Materia materia = new ML.Materia();
                            ML.Usuario usuarioResultado = new ML.Usuario();

                            usuarioResultado.IdUsuario = queryRow.IdUsuario;
                            usuarioResultado.UserName = queryRow.UserName;
                            usuarioResultado.ApellidoPaterno = queryRow.ApellidoPaterno;
                            usuarioResultado.ApellidoMaterno = queryRow.ApellidoMaterno;
                            usuarioResultado.Email = queryRow.Email;
                            usuarioResultado.Password = queryRow.Password;
                            usuarioResultado.Sexo = queryRow.Sexo;
                            usuarioResultado.Telefono = queryRow.Telefono;
                            usuarioResultado.Celular = queryRow.Celular;
                            usuarioResultado.FechaNacimiento = queryRow.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                           // usuarioResultado.FechaNacimiento = queryRow.FechaNacimiento.;
                            usuarioResultado.CURP = queryRow.CURP;
                            usuarioResultado.Rol = new ML.Rol();
                            usuarioResultado.Rol.IdRol = queryRow.IdRol;
                            usuarioResultado.Rol.NombreRol = queryRow.NombreRol;
                            usuarioResultado.Nombre = queryRow.UsuarioNombre;
                            usuarioResultado.Imagen = queryRow.Imagen;
                            usuarioResultado.Direccion = new ML.Direccion();
                            usuarioResultado.Direccion.IdDireccion = queryRow.IdDireccion;
                            usuarioResultado.Direccion.Calle = queryRow.Calle;
                            usuarioResultado.Direccion.NumeroExterior = queryRow.NumeroExterior;
                            usuarioResultado.Direccion.NumeroInterior = queryRow.NumeroInterior;
                            usuarioResultado.Direccion.Colonia = new ML.Colonia();
                            usuarioResultado.Direccion.Colonia.IdColonia = queryRow.IdColonia;
                            usuarioResultado.Direccion.Colonia.Nombre = queryRow.ColoniaNombre;

                            usuarioResultado.Direccion.Colonia.Municipio = new ML.Municipio();
                            usuarioResultado.Direccion.Colonia.Municipio.IdMunicipio = queryRow.IdMunicipio;
                            usuarioResultado.Direccion.Colonia.Municipio.Nombre = queryRow.MunicipioNombre;

                            usuarioResultado.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                            usuarioResultado.Direccion.Colonia.Municipio.Estado.IdEstado = queryRow.IdEstado;
                            usuarioResultado.Direccion.Colonia.Municipio.Estado.Nombre = queryRow.EstadoNombre;

                            usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                            usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais.IdPais = queryRow.IdPais;
                            usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais.Nombre = queryRow.PaisNombre;

                            usuarioResultado.Estatus = queryRow.Estatus.Value;


                            result.Objects.Add(usuarioResultado);

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
        //error pendiente 




        public static ML.Result GetByIDEF(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = context.GetByID(usuario.IdUsuario).FirstOrDefault();
                    //este store procedure no va en una lista porque da un solo resultado 

                    if (query != null)
                    {
                        //
                        // ML.Usuario
                        ML.Usuario usuarioResultado = new ML.Usuario();

                        usuarioResultado.IdUsuario = query.IdUsuario;
                        usuarioResultado.UserName = query.UserName;
                        usuarioResultado.ApellidoPaterno = query.ApellidoPaterno;
                        usuarioResultado.ApellidoMaterno = query.ApellidoMaterno;
                        usuarioResultado.Email = query.Email;
                        usuarioResultado.Password = query.Password;
                        usuarioResultado.Sexo = query.Sexo;
                        usuarioResultado.Telefono = query.Telefono;
                        usuarioResultado.Celular = query.Celular;
                        usuarioResultado.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        //usuarioResultado.FechaNacimiento = query.FechaNacimiento.Value;
                        usuarioResultado.CURP = query.CURP;
                        usuarioResultado.Rol = new ML.Rol();
                        usuarioResultado.Rol.IdRol = query.IdRol;
                        usuarioResultado.Nombre = query.UsuarioNombre;
                        usuarioResultado.Imagen = query.Imagen;
                        usuarioResultado.Direccion = new ML.Direccion();
                        usuarioResultado.Direccion.IdDireccion = query.IdDireccion;
                        usuarioResultado.Direccion.Calle = query.Calle;
                        usuarioResultado.Direccion.NumeroExterior = query.NumeroExterior;
                        usuarioResultado.Direccion.NumeroInterior = query.NumeroInterior;
                        usuarioResultado.Direccion.Colonia = new ML.Colonia();
                        usuarioResultado.Direccion.Colonia.IdColonia = query.IdColonia;
                        usuarioResultado.Direccion.Colonia.Nombre = query.ColoniaNombre;

                        usuarioResultado.Direccion.Colonia.Municipio = new ML.Municipio();
                        usuarioResultado.Direccion.Colonia.Municipio.IdMunicipio = query.IdMunicipio;
                        usuarioResultado.Direccion.Colonia.Municipio.Nombre = query.MunicipioNombre;

                        usuarioResultado.Direccion.Colonia.Municipio.Estado = new ML.Estado();
                        usuarioResultado.Direccion.Colonia.Municipio.Estado.IdEstado = query.IdEstado;
                        usuarioResultado.Direccion.Colonia.Municipio.Estado.Nombre = query.EstadoNombre;

                        usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais = new ML.Pais();
                        usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais.IdPais = query.IdPais;
                        usuarioResultado.Direccion.Colonia.Municipio.Estado.Pais.Nombre = query.PaisNombre;









                        result.Object = usuarioResultado;

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
        /*
                {
                    ML.Result result = new ML.Result();
                    //aqui se crea el objeto que se retorna

                    try
                    {   //manda la cadena de conexion 
                        using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                        {   //cadena que es el procedure

                            string query = "GetByID";

                            //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                            // manda el procedure  y la conexion 
                            using (SqlCommand cmd = new SqlCommand(query, context))
                            {
                                cmd.Parameters.AddWithValue("@ID", usuario.IdUsuario);
                                cmd.CommandType = CommandType.StoredProcedure;

                                DataTable usuarioTable = new DataTable();// creamos una tabla vacia

                                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                                sqlDataAdapter.Fill(usuarioTable); //llenar la tabla que estaba vacia

                                if (usuarioTable.Rows.Count > 0)
                                {
                                    //result.Objects = new List<object>();

                                    // foreach (DataRow item in usuarioTable.Rows)
                                    //{
                                    DataRow item = usuarioTable.Rows[0];
                                    ML.Usuario usuarioResultado = new ML.Usuario();

                                    usuarioResultado.IdUsuario = byte.Parse(item[0].ToString());
                                    usuarioResultado.Nombre = item[1].ToString();
                                    usuarioResultado.ApellidoPaterno = item[2].ToString();
                                    usuarioResultado.ApellidoMaterno = item[3].ToString();
                                    // usuarioResultado.Edad = byte.Parse(item[4].ToString());


                                    result.Object = usuarioResultado;


                                    //  }

                                    result.Correct = true;
                                }

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



                //update Entity famework 


                // aqui van los metodos de identity framework 

                /*  public static ML.Result GetAllEF()
                  {
                      ML.Result result = new ML.Result();

                      try
                      {
                          using (DL_EF.Conexion context = new DL_EF.Conexion())
                          {

                              var usuario = context.ToString();

                              result.Objects = new List<object>();

                              if (alumnos != null)
                              {
                                  foreach (var obj in alumnos)
                                  {
                                      ML.Alumno alumno = new ML.Alumno();
                                      alumno.Matricula = obj.Matricula;
                                      alumno.Nombre = obj.Nombre;
                                      alumno.ApellidoPaterno = obj.ApellidoPaterno;
                                      alumno.ApellidoMaterno = obj.ApellidoMaterno;
                                      alumno.CURP = obj.CURP;
                                      alumno.Telefono = obj.Telefono;

                                      result.Objects.Add(alumno);
                                  }

                                  result.Correct = true;
                              }
                              else
                              {
                                  result.Correct = false;
                                  result.ErrorMessage = "No se encontraron registros.";
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


        public static ML.Result ChangeStatus(byte idUsuario, bool estatus)
        {
            ML.Result result = new ML.Result();
            int query = 0;
            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {  
                         query = context.UsuarioStatus(idUsuario, estatus );
                    

                    if (query >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se insertó el registro";
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




        //Linq



        //aqui van los ejemplos con linq
        // add LINQ


        public static ML.Result AddLQ(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())

                {   //cadena que es el procedure

                    /*
                     DL_EF.Materia materiaLINQ = new DL_EF.Materia();

                    materiaLINQ.Nombre = materia.Nombre;
                    materiaLINQ.Creditos = materia.Creditos;
                    materiaLINQ.Costo = materia.Costo;
                    materiaLINQ.IdSemestre = materia.Semestre.IdSemestre;

                    context.Materias.Add(materiaLINQ); //INSERT INTO MATERIA 
                    int RowsAffected = context.SaveChanges(); 

                     */
                    DL_EF.Usuario usuarioLINQ = new DL_EF.Usuario();
                    usuarioLINQ.UserName = usuario.UserName;
                    usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                    usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                    usuarioLINQ.Email = usuario.Email;
                    usuarioLINQ.Password = usuario.Password;
                    usuarioLINQ.Sexo = usuario.Sexo;
                    usuarioLINQ.Telefono = usuario.Telefono;
                    usuarioLINQ.Celular = usuario.Celular;
                    usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                    
                    usuarioLINQ.CURP = usuario.CURP;
                    // usuario.Rol = new ML.Rol();
                    // usuario.Rol.IdRol = row.IdRol.Value
                    // usuarioLINQ.Rol = new DF_EF.Rol();
                    usuarioLINQ.IdRol = usuario.Rol.IdRol;
      
                    usuarioLINQ.Nombre = usuario.Nombre;

                    context.Usuarios.Add(usuarioLINQ);
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


        public static ML.Result UpdateLINQ(ML.Usuario usuario)
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

                    var usuarioLINQ = (from queryLINQ in context.Usuarios
                                       where queryLINQ.IdUsuario == usuario.IdUsuario
                                       select queryLINQ).SingleOrDefault();

                    if (usuarioLINQ != null)
                    {
                        //DL_EF.Usuario  = new DL_EF.Usuario();
                        //usuarioLINQ.IdUsuario = usuario.IdUsuario;
                        usuarioLINQ.UserName = usuario.UserName;
                        usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioLINQ.Email = usuario.Email;
                        usuarioLINQ.Password = usuario.Password;
                        usuarioLINQ.Sexo = usuario.Sexo;
                        usuarioLINQ.Telefono = usuario.Telefono;
                        usuarioLINQ.Celular = usuario.Celular;
                        usuarioLINQ.FechaNacimiento = DateTime.Parse(usuario.FechaNacimiento);
                        usuarioLINQ.CURP = usuario.CURP;
                        // usuario.Rol = new ML.Rol();
                        // usuario.Rol.IdRol = row.IdRol.Value
                        // usuarioLINQ.Rol = new DF_EF.Rol();
                        usuarioLINQ.IdRol = usuario.Rol.IdRol;

                        usuarioLINQ.Nombre = usuario.Nombre;

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

        //detele LINQ

        public static ML.Result DeleteLINQ(ML.Usuario usuario)
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
                     using (var ctx = new MyEntity())
    {
        var x = (from y in ctx.Employees
             orderby  y.EmployeeId descending
             select y).FirstOrDefault();
        ctx.Employees.Remove(x);
        ctx.SaveChanges();
    }
 
                     */

                    var usuarioLINQ = (from queryLINQ in context.Usuarios
                                       where queryLINQ.IdUsuario == usuario.IdUsuario
                                       select queryLINQ).SingleOrDefault();

                    if (usuarioLINQ != null)
                    {
                        //DL_EF.Usuario  = new DL_EF.Usuario();
                        //usuarioLINQ.IdUsuario = usuario.IdUsuario;
                        /*
                        usuarioLINQ.UserName = usuario.UserName;
                        usuarioLINQ.ApellidoMaterno = usuario.ApellidoMaterno;
                        usuarioLINQ.ApellidoPaterno = usuario.ApellidoPaterno;
                        usuarioLINQ.Email = usuario.Email;
                        usuarioLINQ.Password = usuario.Password;
                        usuarioLINQ.Sexo = usuario.Sexo;
                        usuarioLINQ.Telefono = usuario.Telefono;
                        usuarioLINQ.Celular = usuario.Celular;
                        usuarioLINQ.FechaNacimiento = usuario.FechaNacimiento;
                        usuarioLINQ.CURP = usuario.CURP;
                        // usuario.Rol = new ML.Rol();
                        // usuario.Rol.IdRol = row.IdRol.Value
                        // usuarioLINQ.Rol = new DF_EF.Rol();
                        usuarioLINQ.IdRol = usuario.Rol.IdRol;

                        usuarioLINQ.Nombre = usuario.Nombre;
                        */
                        context.Usuarios.Remove(usuarioLINQ);
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


        //Get all LINQ

        public static ML.Result GetAllLINQ()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = (from usuarioLINQ in context.Usuarios //FROM Materia
                                 join rolLINQ in context.Rol on usuarioLINQ.IdRol equals rolLINQ.IdRol
                                 //  join aliasVaraiable in tablaModeloB on tablaModeloA.FK equals tablaModeloB.PK
                                 select new
                                 {
                                     Idusuario = usuarioLINQ.IdUsuario,
                                     UserName = usuarioLINQ.UserName,
                                     ApellidoPaterno =usuarioLINQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLINQ.ApellidoMaterno,
                                     Email = usuarioLINQ.Email,
                                     Password = usuarioLINQ.Password,
                                     Sexo = usuarioLINQ.Sexo,
                                     Telefono = usuarioLINQ.Telefono,
                                     Celular = usuarioLINQ.Celular,
                                     FechaNacimiento = usuarioLINQ.FechaNacimiento,
                                     CURP = usuarioLINQ.CURP,
                                     IDRol = usuarioLINQ.IdRol,
                                     Nombre = usuarioLINQ.Nombre,
                                     NombreRol = rolLINQ.NombreRol,
                                   
                                 });

                    result.Objects = new List<object>();

                    if (query != null && query.ToList().Count > 0)
                    {
                        foreach (var obj in query)
                        {
                            ML.Usuario usuario = new ML.Usuario();

                            usuario.IdUsuario = obj.Idusuario;
                            usuario.UserName = obj.UserName;
                            usuario.ApellidoPaterno = obj.ApellidoPaterno;
                            usuario.ApellidoMaterno = obj.ApellidoMaterno;
                            usuario.Email = obj.Email;
                            usuario.Password = obj.Password;
                            usuario.Sexo = obj.Sexo;
                            usuario.Telefono = obj.Telefono;
                            usuario.Celular = obj.Celular;
                            usuario.FechaNacimiento = obj.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                            usuario.CURP = obj.CURP;
                            usuario.Nombre = obj.Nombre;



                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = obj.IDRol;
                            usuario.Rol.NombreRol = obj.NombreRol;
                            result.Objects.Add(usuario);
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

        //get by id Linq
        //*

        public static ML.Result GetByIDLINQ(ML.Usuario usuarioEntrada)
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = (from usuarioLINQ in context.Usuarios //FROM Materia
                                 join rolLINQ in context.Rol on usuarioLINQ.IdRol equals rolLINQ.IdRol
                                 where usuarioLINQ.IdUsuario == usuarioEntrada.IdUsuario
                                 //  join aliasVaraiable in tablaModeloB on tablaModeloA.FK equals tablaModeloB.PK
                                 select new
                                 {
                                     Idusuario = usuarioLINQ.IdUsuario,
                                     UserName = usuarioLINQ.UserName,
                                     ApellidoPaterno = usuarioLINQ.ApellidoPaterno,
                                     ApellidoMaterno = usuarioLINQ.ApellidoMaterno,
                                     Email = usuarioLINQ.Email,
                                     Password = usuarioLINQ.Password,
                                     Sexo = usuarioLINQ.Sexo,
                                     Telefono = usuarioLINQ.Telefono,
                                     Celular = usuarioLINQ.Celular,
                                     FechaNacimiento = usuarioLINQ.FechaNacimiento,
                                     CURP = usuarioLINQ.CURP,
                                     IDRol = usuarioLINQ.IdRol,
                                     Nombre = usuarioLINQ.Nombre,
                                     NombreRol = rolLINQ.NombreRol,

                                 }).SingleOrDefault();
                    
                    /// EL Single Or Defaut sirve para aclarar que se retornna un solo objeto 
                  //  result.Objects = new List<object>();

                    if (query != null )
                    {
                        // foreach (var obj in query)
                        // {

                        
                            ML.Usuario usuario = new ML.Usuario();

                        usuario.IdUsuario = query.Idusuario;
                            usuario.UserName = query.UserName;
                            usuario.ApellidoPaterno = query.ApellidoPaterno;
                            usuario.ApellidoMaterno = query.ApellidoMaterno;
                            usuario.Email = query.Email;
                            usuario.Password = query.Password;
                            usuario.Sexo = query.Sexo;
                            usuario.Telefono = query.Telefono;
                            usuario.Celular = query.Celular;
                            usuario.FechaNacimiento = query.FechaNacimiento.Value.ToString("dd/MM/yyyy");
                        usuario.CURP = query.CURP;
                            usuario.Nombre = query.Nombre;



                            usuario.Rol = new ML.Rol();
                            usuario.Rol.IdRol = query.IDRol;
                            usuario.Rol.NombreRol = query.NombreRol;
                            result.Object = usuario;
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

        //aqui van los metodos de la tabla empresa 

        //add empresa




    }
}
