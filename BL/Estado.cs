using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ML;

namespace BL
{
    public class Estado
    {
        public static ML.Result EstadoGetByIdPais(int? IdPais)
        {
            ML.Result resultEstado = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {   //cadena que es el procedure

                    string query = "EstadoGetByIdPais";
                   

                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@IdPais", IdPais);
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable estadoTable = new DataTable();// creamos una tabla vacia

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                        sqlDataAdapter.Fill(estadoTable); //llenar la tabla que estaba vacia

                        if (estadoTable.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();

                            // foreach (DataRow item in usuarioTable.Rows)
                            //{
                            resultEstado.Objects = new List<object>();

                            foreach (DataRow item in estadoTable.Rows)
                            {
                                ML.Estado estadoResultado = new ML.Estado();

                                estadoResultado.IdEstado = int.Parse(item[0].ToString());
                                estadoResultado.Nombre = item[1].ToString();

                                // usuario.Edad = byte.Parse(item[4].ToString());


                                resultEstado.Objects.Add(estadoResultado);



                                //  }

                                resultEstado.Correct = true;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                resultEstado.Correct = false;
                resultEstado.Ex = ex;
                resultEstado.ErrorMessage = "Ocurrio un error al realizar la consulta en la base de datos " + resultEstado.Ex;
                //throw;
            }

            return resultEstado;
        }


    }
}
