using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Empresa" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Empresa.svc or Empresa.svc.cs at the Solution Explorer and start debugging.
    public class Empresa : IEmpresa
    {
        public void DoWork()
        {
        }



        public ML.Result EmpresaAdd(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            result = BL.Empresa.EmpresaAdd(empresa);
            return result;
        }

        public ML.Result EmpresaUpdate(ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();

            result = BL.Empresa.EmpresaUpdate(empresa);
            return result;
        }



        public ML.Result EmpresaDelete(ML.Empresa empresa)
        {

        
            ML.Result result = new ML.Result();

            result = BL.Empresa.EmpresaDelete(empresa);
            return result;
        }


        public ML.Result EmpresaGetAll()

        {


            ML.Result result = new ML.Result();

            result = BL.Empresa.EmpresaGetAll();
            return result;
        }

        public ML.Result EmpresaGetById(ML.Empresa empresa)
        {

        
            ML.Result result = new ML.Result();

             result = BL.Empresa.EmpresaGetById(empresa);
            return result;
        }



      







    }
}
