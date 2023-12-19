using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SL_WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IEmpresa" in both code and config file together.
    [ServiceContract]
    public interface IEmpresa
    {
        [OperationContract]
        void DoWork();

        [OperationContract]

        ML.Result EmpresaAdd(ML.Empresa empresa);
        [OperationContract]

        ML.Result EmpresaUpdate(ML.Empresa empresa);


        [OperationContract]

        ML.Result EmpresaDelete(ML.Empresa empresa);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Empresa))]
        ML.Result EmpresaGetById(ML.Empresa empresa);


        [OperationContract]
        [ServiceKnownType(typeof(ML.Empresa))]

        ML.Result EmpresaGetAll();








    }
}
