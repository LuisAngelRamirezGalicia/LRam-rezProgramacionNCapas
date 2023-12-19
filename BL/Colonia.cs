using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Colonia
    {
        public static ML.Result GetByIdMunicipio(int IdMunicipio)
        {
            ML.Result resultColonia = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {   //cadena que es el procedure

                    string query = "ColoniaGetByIdMunicipio";


                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@IdMunicipio", IdMunicipio);
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable coloniaTable = new DataTable();// creamos una tabla vacia

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                        sqlDataAdapter.Fill(coloniaTable); //llenar la tabla que estaba vacia

                        if (coloniaTable.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();

                            // foreach (DataRow item in usuarioTable.Rows)
                            //{
                            resultColonia.Objects = new List<object>();

                            foreach (DataRow item in coloniaTable.Rows)
                            {
                                ML.Colonia coloniaResultado = new ML.Colonia();

                                coloniaResultado.IdColonia = int.Parse(item[0].ToString());
                                coloniaResultado.Nombre = item[1].ToString();

                                // usuario.Edad = byte.Parse(item[4].ToString());


                                resultColonia.Objects.Add(coloniaResultado);



                                //  }

                                resultColonia.Correct = true;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                resultColonia.Correct = false;
                resultColonia.Ex = ex;
                resultColonia.ErrorMessage = "Ocurrio un error al realizar la consulta en la base de datos " + resultColonia.Ex;
                //throw;
            }

            return resultColonia;
        }
    }
}
