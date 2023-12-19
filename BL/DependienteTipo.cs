using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class DependienteTipo
    {
        public static ML.Result DependienteTipoGetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL_EF.LRamirezProgramacionNCapasEntities2 context = new DL_EF.LRamirezProgramacionNCapasEntities2())
                {
                    var query = context.DependienteTipoGetAll();

                    if (query != null)
                    {
                        result.Objects = new List<object>();

                        foreach (var row in query)
                        {
                            //ML.Materia materia = new ML.Materia();
                            ML.DependienteTipo dependienteTipo = new ML.DependienteTipo();

                            /*  materia.IdMateria = row.IdMateria;
                              materia.Nombre = row.Nombre;
                              materia.Creditos = row.Creditos.Value;
                              materia.Costo = row.Costo.Value;

                              materia.Semestre = new ML.Semestre();
                              materia.Semestre.IdSemestre = row.IdSemestre.Value;
                              result.Objects.Add(materia);*/

                            dependienteTipo.IdDependienteTipo = row.IdDependienteTipo;
                            dependienteTipo.Nombre = row.Nombre;



                            result.Objects.Add(dependienteTipo);

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
