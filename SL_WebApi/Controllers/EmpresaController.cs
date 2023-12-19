using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL_WebApi.Controllers
{
    public class EmpresaController : ApiController
    {
        // GET: api/Empresa

        [Route("api/empresa/get")]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/empresa/getall")]
        public IHttpActionResult GetAll()
        {
            ML.Result result = new ML.Result();
            result = BL.Empresa.EmpresaGetAllLINQ();
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpPost]

        [Route("api/empresa/add")]
        public IHttpActionResult add([FromBody] ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            result = BL.Empresa.EmpresaAdd(empresa);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }

        [HttpPut]

        [Route("api/empresa/update")]
        public IHttpActionResult update([FromBody] ML.Empresa empresa)
        {
            ML.Result result = new ML.Result();
            result = BL.Empresa.EmpresaUpdate(empresa);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }


        [HttpDelete]

        [Route("api/empresa/delete/{IdEmpresa}")]
        public IHttpActionResult delete(int IdEmpresa)
        {   ML.Empresa empresa = new ML.Empresa();
            empresa.IdEmpresa = IdEmpresa;
            ML.Result result = new ML.Result();
            result = BL.Empresa.EmpresaDelete(empresa);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }


        [Route("api/empresa/getbyid/{IdEmpresa}")] // enviar parametros ->IdDepartamento
        [HttpGet]

        // Get api/departamento
        public IHttpActionResult getbyid(int IdEmpresa)
        { ML.Empresa empresa = new ML.Empresa();
            empresa.IdEmpresa = IdEmpresa;
            ML.Result result = BL.Empresa.EmpresaGetById(empresa);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
               return BadRequest(result.ErrorMessage);
               // return Content(HttpStatusCode.NotFound, result);
            }
        }






        // GET: api/Empresa/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Empresa
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Empresa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empresa/5
        public void Delete(int id)
        {
        }
    }
}
