using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Municipio
    {
        public static ML.Result GetByIdEstado (int IdEstado)
        {
            ML.Result resultMunicipio = new ML.Result();
            //aqui se crea el objeto que se retorna

            try
            {   //manda la cadena de conexion 
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnectionString()))
                {   //cadena que es el procedure

                    string query = "MunicipioGetByIdEstado";


                    //cmd.Parameters.AddWithValue("@ID", usuario.ID);
                    // manda el procedure  y la conexion 
                    using (SqlCommand cmd = new SqlCommand(query, context))
                    {
                        cmd.Parameters.AddWithValue("@IdEstado", IdEstado);
                        cmd.CommandType = CommandType.StoredProcedure;

                        DataTable municipioTable = new DataTable();// creamos una tabla vacia

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd); //enviamos el cmd 

                        sqlDataAdapter.Fill(municipioTable); //llenar la tabla que estaba vacia

                        if (municipioTable.Rows.Count > 0)
                        {
                            //result.Objects = new List<object>();

                            // foreach (DataRow item in usuarioTable.Rows)
                            //{
                            resultMunicipio.Objects = new List<object>();

                            foreach (DataRow item in municipioTable.Rows)
                            {
                                ML.Municipio municipioResultado = new ML.Municipio();

                                municipioResultado.IdMunicipio = int.Parse(item[0].ToString());
                                municipioResultado.Nombre = item[1].ToString();

                                // usuario.Edad = byte.Parse(item[4].ToString());


                                resultMunicipio.Objects.Add(municipioResultado);



                                //  }

                                resultMunicipio.Correct = true;
                            }
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                resultMunicipio.Correct = false;
                resultMunicipio.Ex = ex;
                resultMunicipio.ErrorMessage = "Ocurrio un error al realizar la consulta en la base de datos " + resultMunicipio.Ex;
                //throw;
            }

            return resultMunicipio;
        }
    }
}
