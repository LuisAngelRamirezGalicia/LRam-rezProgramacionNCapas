using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Rol
    {
        public static ML.Result GetAllEF()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = context.RolGetAll().ToList();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            //ML.Materia materia = new ML.Materia();
                           // ML.Usuario usuario = new ML.Usuario();
                            ML.Rol rol = new ML.Rol();
                           
                            rol.IdRol = row.IdRol;
                            rol.NombreRol = row.NombreRol;
                           // usuario.Rol = rol;
                            //usuario.Rol.IdRol = rol.IdRol;
                            //usuario.Rol.NombreRol= rol.NombreRol;

                            result.Objects.Add(rol);

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


    }
}
