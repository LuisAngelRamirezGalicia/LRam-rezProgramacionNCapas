using ML;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Pais
    {
        public static ML.Result GetAllPais()
        {
            ML.Result result = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {   //cadena que es el procedure
                    string query = "GetAllPais";
                    // manda el procedure  y la conexion 
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {   //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable paisTable = new DataTable();// creamos una tabla vacia

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                        sqlDataAdapter.Fill(paisTable); //llenar la tabla que estaba vacia

                        if (paisTable.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();

                            foreach (DataRow item in paisTable.Rows)
                            {
                                ML.Pais pais = new ML.Pais();

                                pais.IdPais = int.Parse(item[0].ToString());
                                pais.Nombre = item[1].ToString();

                                // usuario.Edad = byte.Parse(item[4].ToString());


                                result.Objects.Add(pais);


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


    }
}
